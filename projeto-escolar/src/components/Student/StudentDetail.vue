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
            }
        },
    }
</script>

<style scoped>
.btnEdit {
    float: right;
    background-color: rgb(76, 186, 249);
}
.colSmall {
    width: 20%;
    text-align: right;
    background-color: rgb(125, 217, 245);
    font-weight: bold;
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