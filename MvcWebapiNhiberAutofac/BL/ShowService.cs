using MvcWebapiNhiberAutofac.DAL;
using MvcWebapiNhiberAutofac.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.BL
{
    public class ShowService : IShowService
    {
        IRepository context;

        public ShowService(IRepository context)
        {
            this.context = context;
        }

        public async Task AddRange(IList<ShowModel> range, int page)
        {
            var result = range.Select(x => new Show { Id = x.Id, Page = page, Name = x.Name });

            await context.AddRange(result);
        }

        public async Task<IEnumerable<ShowModel>> GetAll()
        {
            var shows = await context.GetAll();

            var result = shows.Select(x => new ShowModel { Id = x.Id, Name = x.Name });

            return result;
        }

        public async Task<IEnumerable<ShowModel>> GetShowsPerPage(int page)
        {
            var shows = await context.GetShowsPerPage(page);

            var result = shows.Select(x => new ShowModel { Id = x.Id, Name = x.Name });

            return result;
        }

        public async Task<bool> IfPageExists(int page)
        {
            return await context.IfPageExists(page);
        }
    }
}