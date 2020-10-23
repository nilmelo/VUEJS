<template>
    <div>
        <Title text_info="Professores"/>
        <table border="1px">
			<thead>
				<th>Código</th>
				<th>Nome</th>
				<th>Alunos</th>
			</thead>
			<tbody v-if="professors.length">
				<tr v-for="(professor, index) in professors" :key="index">
					<td>{{ professor.id }}</td>
                    <router-link :to="`/alunos/${professor.id}`" tag="td" style="cursor: pointer">
                        {{ professor.name }} {{ professor.lastname }}
                    </router-link>
					<td>
                        {{ professor.qtyStudents }}
                    </td>
				</tr>
			</tbody>
			<tfoot v-else>
				Nenhum Aluno Encontrado.
			</tfoot>
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
               students: []
           }
       },
       created() {
		this.$http
			.get('http://localhost:3000/students')
			.then(res => res.json())
			.then(students => {
                this.students = students;
                this.loadProfessors();
            });
        },
        props: {},
        methods: {
            getQtyStudentsPerProfessor() {
                this.professors.forEach((professor, index) => {
                    professor = {
                        id: professor.id,
                        name: professor.name,
                        qtyStudents: this.students.filter(student => 
                            student.professor.id == professor.id)
                            .length
                    }
                    this.professors[index] = professor;
                });
            },
            loadProfessors() {
                this.$http
                    .get('http://localhost:3000/professors')
                    .then(res => res.json())
                    .then(professors => {
                        this.professors = professors;
                        this.getQtyStudentsPerProfessor();
                    });
            }   
        }
    }
</script>

<style scoped>

</style>