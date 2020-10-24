using System.Threading.Tasks;

namespace ProjetoEscolar.WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();
    }
}