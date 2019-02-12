using MvcWebapiNhiberAutofac.Models;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.BL
{
    public interface IScraperService
    {
        Task<ShowModel[]> GetShowsAsync(int index);
        Task<CastModel[]> GetCastsAsync(int index);
    }
}