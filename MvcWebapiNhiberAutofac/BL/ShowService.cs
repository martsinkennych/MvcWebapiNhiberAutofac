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
            var result = await Task.Run(() => range.Select(x => new Show { Id = x.Id, Page = page, Name = x.Name }).ToList());

            await Task.Run(() => context.AddRange(result));
        }

        public async Task<IList<ShowModel>> GetAll()
        {
            IList<ShowModel> result = null;
            
            var shows = await Task.Run(() => context.GetAll());

            result = await Task.Run(() => shows.Select(x => new ShowModel { Id = x.Id, Name = x.Name }).ToList());

            return result;
        }

        public async Task<IList<ShowModel>> GetShowsPerPage(int page)
        {
            IList<ShowModel> result = null;

            var shows = await Task.Run(() => context.GetShowsPerPage(page));

            result = await Task.Run(() => shows.Select(x => new ShowModel { Id = x.Id, Name = x.Name }).ToList());

            return result;
        }

        public async Task<bool> IfPageExists(int page)
        {
            return await Task.Run(() => context.IfPageExists(page));
        }
    }
}