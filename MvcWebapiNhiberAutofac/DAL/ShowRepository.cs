using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.DAL
{
    public class ShowRepository : IRepository
    {
        public async Task AddRange(IEnumerable<Show> range)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach(var show in range)
                        await session.SaveAsync(show);
                    transaction.Commit();
                }
            }
        }

        public async Task<IList<Show>> GetAll()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return await session.Query<Show>().ToListAsync();
            }
        }

        public async Task<IList<Show>> GetShowsPerPage(int page)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return await session.Query<Show>().Where(x => x.Page == page).ToListAsync();
            }
        }

        public async Task<bool> IfPageExists(int page)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                if (session.Query<Show>().Count() > 0)
                {
                    return await session.Query<Show>().Where(x => x.Page == page).AnyAsync();
                }
                else
                    return false;
            }
        }
    }
}