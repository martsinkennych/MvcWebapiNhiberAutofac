using MvcWebapiNhiberAutofac.BL;
using MvcWebapiNhiberAutofac.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace MvcWebapiNhiberAutofac.Api
{
    public class CastsController : ApiController
    {
        IShowService showService;
        IScraperService scraperService;
        public CastsController(IShowService showService, IScraperService scraperService)
        {
            this.showService = showService;
            this.scraperService = scraperService;
        }

        [HttpGet]
        // GET: api/casts/5
        public async Task<IHttpActionResult> Get(int id)
        {
            var show = await showService.GetShow(id);

            if (show != null)
            {
                var castInfo = await scraperService.GetCastsAsync(id);
                show.Cast = castInfo.OrderBy(x => x.Person.Birthday);
                var showDesc = new ShowDescription
                {
                    Id = show.Id,
                    Name = show.Name,
                    Cast = show.Cast.Select(x => new CastDesciption { Id = x.Person.Id, Name = x.Person.Name, Birthday = x.Person.Birthday }).ToArray()
                };

                return Ok(showDesc);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteShow(int id)
        {
            var show = await showService.GetShow(id);

            if (show != null)
            {
                await showService.DeleteShow(id);

                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditShow(int id, [FromBody] string name)
        {
            var show = await showService.GetShow(id);

            if (show != null)
            {
                await showService.EditShow(id, name);

                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddShow([FromBody] string name)
        {
            await showService.AddShow(name);

            return Ok();
        }
    }
}
