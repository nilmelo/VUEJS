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
                    <router-link to="/alunos" tag="td" style="cursor: pointer">
                        {{ professor.name }} {{ professor.lastname }}
                    </router-link>
					<td>3</td>
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
               professors: [
                   { id: 1, name: 'Nilson' },
                   { id: 2, name: 'Alexandre' },
                   { id: 3, name: 'Manoela' }
               ]
           }
       } 
    }
</script>

<style scoped>

</style>