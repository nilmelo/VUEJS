using System.Threading.Tasks;
using ProjetoEscolar.WebAPI.Models;

namespace ProjetoEscolar.WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Student[]> GetAllStudentsAsync(bool includeProfessor);
        Task<Student[]> GetStudentsAsyncByProfessorId(int ProfessorId, bool includeProfessor);
        Task<Student> GetStudentAsyncById(int StudentId, bool includeProfessor);

        //PROFESSOR
        Task<Professor[]> GetAllProfessorsAsync(bool includeStudent);
        Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeStudent);
    }
}