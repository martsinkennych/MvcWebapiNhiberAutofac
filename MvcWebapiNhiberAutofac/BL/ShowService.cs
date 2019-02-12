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

        public async Task<ShowModel> GetShow(int id)
        {
            var show = await context.GetShow(id);

            if (show != null)
            {
                ShowModel result = new ShowModel { Id = show.Id, Page = show.Page, Name = show.Name };

                return result;
            }
            else
                return null;
        }

        public async Task DeleteShow(int id)
        {
            await context.DeleteShow(id);
        }

        public async Task<bool> IfPageExists(int page)
        {
            return await context.IfPageExists(page);
        }

        public async Task EditShow(int id, string name)
        {
            await context.EditShow(id, name);
        }

        public async Task AddShow(string name)
        {
            await context.AddShow(name);
        }
    }
}