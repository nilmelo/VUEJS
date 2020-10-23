<template>
	<div>
		<Title text_info="Alunos" />
		<div>
			<input
				type="text"
				placeholder="Nome do Aluno"
				v-model="name"
				@keyup.enter="addStudent()"
			/>
			<button class="btn btnInput" @click="addStudent()">
				Adicionar
			</button>
		</div>

		<table border="1px">
			<thead>
				<th>Matrícula</th>
				<th>Nome</th>
				<th>Opções</th>
			</thead>
			<tbody v-if="students.length">
				<tr v-for="(student, index) in students" :key="index">
					<td>{{ student.id }}</td>
					<td>{{ student.name }} {{ student.lastname }}</td>
					<td>
						<button class="btn btn_danger" @click="remove(student)">
							Remover
						</button>
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
import Title from "../shared/Title";

export default {
	components: {
		Title,
	},
	data() {
		return {
			title: "Aluno",
			professorid: this.$route.params.prof_id,
			name: "",
			students: [],
		};
	},
	created() {
		if (this.professorid) {
			this.$http
				.get(
					"http://localhost:3000/students?professor.id=" +
						this.professorid
				)
				.then((res) => res.json())
				.then((students) => (this.students = students));
		} else {
			this.$http
				.get("http://localhost:3000/students")
				.then((res) => res.json())
				.then((students) => (this.students = students));
		}
	},
	props: {},
	methods: {
		addStudent() {
			let _student = {
				name: this.name,
				lastname: "",
			};

			this.$http
				.post("http://localhost:3000/students", _student)
				.then((res) => res.json())
				.then((studentReturned) => {
					this.students.push(studentReturned);
					this.name = "";
				});
		},
		remove(student) {
			this.$http
				.delete(`http://localhost:3000/students/${student.id}`)
				.then(() => {
					let i = this.students.indexOf(student);
					this.students.splice(i, 1);
				});
		},
	},
};
</script>

<style scoped>
input {
	width: calc(100% - 195px);
	border: 0;
	padding: 20px;
	font-size: 1.3em;
	color: #687f7f;
}
.btnInput {
	width: 150px;
	border: 0px;
	padding: 20px;
	font-size: 1.3em;
	background-color: rgb(116, 115, 115);
}
.btnInput:hover {
	padding: 20px;
	margin: 0px;
	border: 0px;
	background-color: rgb(175, 173, 173);
}
</style>
