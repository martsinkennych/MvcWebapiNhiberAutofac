using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.DAL
{
    public interface IRepository
    {
        IList<Show> GetAll();
        IList<Show> GetShowsPerPage(int page);
        bool IfPageExists(int page);
        void AddRange(List<Show> range);
    }
}