import Vue from 'vue';
import Router from 'vue-router';
import Students from './components/Student/Students';
import Professor from './components/Professor/Professor'
import About from './components/About/About'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/professores',
            name: 'Professores',
            component: Professor
        },
        {
            path: '/alunos',
            name: 'Alunos',
            component: Students
        },
        {
            path: '/sobre',
            name: 'Sobre',
            component: About
        },
    ]
})