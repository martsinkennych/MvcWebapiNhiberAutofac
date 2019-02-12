using MvcWebapiNhiberAutofac.BL;
using MvcWebapiNhiberAutofac.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcWebapiNhiberAutofac.Controllers
{
    public class ShowsController : Controller
    {
        IShowService showService;
        IScraperService scraperService;

        public ShowsController(IShowService showService, IScraperService scraperService)
        {
            this.showService = showService;
            this.scraperService = scraperService;
        }

        // GET: Shows
        public async Task<ActionResult> Index(int page = 0)
        {
            if(!await showService.IfPageExists(page == 0 ? 1 : page)) 
            {
                //обращение к апи
                var pageShows = await scraperService.GetShowsAsync(page != 0 ? page - 1 : 0);
                //добавление в базу
                await showService.AddRange(pageShows, page == 0 ? 1 : page);
            }

            if (page == 0)
                page = 1;

            var shows = await showService.GetShowsPerPage(page);

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = shows.Count(), TotalPages = 200 };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Shows = shows };

            return View(ivm);
        }
    }
}