using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.DAL
{
    public interface IRepository
    {
        Task<IList<Show>> GetAll();
        Task<IList<Show>> GetShowsPerPage(int page);
        Task<bool> IfPageExists(int page);
        Task AddRange(IEnumerable<Show> range);
    }
}