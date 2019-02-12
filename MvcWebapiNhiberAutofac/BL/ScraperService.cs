using MvcWebapiNhiberAutofac.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.BL
{
    public class ScraperService : IScraperService
    {
        public async Task<ShowModel[]> GetShowsAsync(int index)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"http://api.tvmaze.com/shows?page={index}");

                return JsonConvert.DeserializeObject<ShowModel[]>(json);
            }
        }

        public async Task<CastModel[]> GetCastsAsync(int index)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"http://api.tvmaze.com/shows/{index}/cast");

                return JsonConvert.DeserializeObject<CastModel[]>(json);
            }
        }
    }
}