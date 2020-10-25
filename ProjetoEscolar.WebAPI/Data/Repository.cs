using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoEscolar.WebAPI.Models;

namespace ProjetoEscolar.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        // ALUNOS
        public async Task<Student[]> GetAllStudentsAsync(bool includeProfessor = false)
        {
            IQueryable<Student> query = _context.Students;

            if(includeProfessor)
            {
                query = query.Include(s => s.Professor);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student[]> GetStudentsAsyncByProfessorId(int ProfessorId, bool includeProfessor)
        {
            IQueryable<Student> query = _context.Students;

            if(includeProfessor)
            {
                query = query.Include(s => s.Professor);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(student => student.ProfessorId == ProfessorId);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentAsyncById(int StudentId, bool includeProfessor)
        {
            IQueryable<Student> query = _context.Students;

            if(includeProfessor)
            {
                query = query.Include(s => s.Professor);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(student => student.Id == StudentId);

            return await query.FirstOrDefaultAsync();
        }

        // PROFESSORES
        public async Task<Professor[]> GetAllProfessorsAsync(bool includeStudent = false)
        {
            IQueryable<Professor> query = _context.Professors;

            if(includeStudent)
            {
                query = query.Include(s => s.Students);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(a => a.Id);
                        
            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeStudent = false)
        {
            IQueryable<Professor> query = _context.Professors;

            if(includeStudent)
            {
                query = query.Include(s => s.Students);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(professor => professor.Id == ProfessorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}