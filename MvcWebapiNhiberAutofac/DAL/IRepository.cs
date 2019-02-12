using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.DAL
{
    public interface IRepository
    {
        Task<IList<Show>> GetAll();
        Task<IList<Show>> GetShowsPerPage(int page);
        Task<Show> GetShow(int id);
        Task<bool> IfPageExists(int page);
        Task AddRange(IEnumerable<Show> range);
        Task DeleteShow(int id);
        Task EditShow(int id, string name);

        Task AddShow(string name);
    }
}