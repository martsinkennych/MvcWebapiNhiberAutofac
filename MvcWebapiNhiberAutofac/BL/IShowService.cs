using MvcWebapiNhiberAutofac.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.BL
{
    public interface IShowService
    {
        Task<IEnumerable<ShowModel>> GetAll();
        Task<IEnumerable<ShowModel>> GetShowsPerPage(int page);
        Task<ShowModel> GetShow(int id);
        Task DeleteShow(int id);
        Task<bool> IfPageExists(int page);
        Task AddRange(IList<ShowModel> range, int page);
        Task EditShow(int id, string name);
        Task AddShow(string name);
    }
}