<template>
    <div>
        <Title :text_info="`Aluno: ${student.name}`" :btnBack="!visualize">
            <button v-show="visualize" class="btn btnEdit" @click="editToggle()">Editar</button>
        </Title>
        <table>
            <tbody>
                <tr>
                    <td class="colSmall">Matrícula:</td>
                    <td>
                        <label>{{ student.id }}</label>
                    </td>
                </tr>
                <tr>
                    <td class="colSmall">Nome:</td>
                    <td>
                        <label v-if="visualize">{{ student.name }}</label>
                        <input v-else v-model="student.name" type="text">
                    </td>
                </tr>
                <tr>
                    <td class="colSmall">Sobrenome:</td>
                    <td>
                        <label v-if="visualize">{{ student.lastname }}</label>
                        <input v-else v-model="student.lastname" type="text">
                    </td>
                </tr>
                <tr>
                    <td class="colSmall">Data Nascimento:</td>
                    <td>
                        <label v-if="visualize">{{ student.dateBirth }}</label>
                        <input v-else v-model="student.dateBirth" type="text">
                    </td>
                </tr>
                <tr>
                    <td class="colSmall">Professor:</td>
                    <td>
                        <label v-if="visualize">{{ student.professor.name }}</label>
                        <select v-else v-model="student.professor">
                            <option v-for="(professor, index) in professors"
                            :key="index" v-bind:value="professor">
                                {{ professor.name }}
                            </option>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
        <div style="margin-top: 10px">
            <div v-if="!visualize">
                <button class="btn btnSave" @click="save(student)">
                    Salvar
                </button>
                <button class="btn btnCancel" @click="cancel()">
                    Cancelar
                </button>
            </div>
        </div>
    </div>
</template>

<script>
    import Title from '../shared/Title'

    export default {
        components: {
            Title
        },
        data() {
            return {
                professors: [],
                student: {},
                id: this.$route.params.id,
                visualize: true
            }
        },
        created() {
            this.$http
				.get("http://localhost:3000/students/" + this.id)
				.then((res) => res.json())
                .then((student) => (this.student = student));
                
            this.$http
                    .get('http://localhost:3000/professors')
                    .then(res => res.json())
                    .then(professors => this.professors = professors);
        },
        methods: {
            editToggle() {
                this.visualize = !this.visualize;
            },
            save(_student) {
                let _studentEdit = {
                    id: _student.id,
                    name: _student.name,
                    lastname: _student.lastname,
                    dateBirth: _student.dateBirth,
                    professor: _student.professor,
                }

                this.$http
                    .put(`http://localhost:3000/students/${_student.id}`, _studentEdit);

                this.visualize = !this.visualize;
            },
            cancel() {
                this.visualize = !this.visualize;
            }
        },
    }
</script>

<style scoped>
.btnEdit {
    float: right;
    background-color: rgb(76, 186, 249);
}
.btnSave {
    float: right;
    background-color: rgb(79, 196, 68);
}
.btnCancel {
    float: left;
    background-color: rgb(249, 186, 92);
}
.colSmall {
    width: 20%;
}
input, select {
    margin: 0px;
    padding: 5px 10px;
    font-size: 0.9em;
    font-family: Montserrat;
    border-radius: 5px;
    border: 1px solid silver;
    background-color: rgb(245, 245, 245);
    width: 95%;
}
select {
    height: 38px;
    width: 100%;
}
</style>