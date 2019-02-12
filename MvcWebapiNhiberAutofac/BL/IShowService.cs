using MvcWebapiNhiberAutofac.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.BL
{
    public interface IShowService
    {
        Task<IList<ShowModel>> GetAll();
        Task<IList<ShowModel>> GetShowsPerPage(int page);
        Task<bool> IfPageExists(int page);
        Task AddRange(IList<ShowModel> range, int page);
    }
}