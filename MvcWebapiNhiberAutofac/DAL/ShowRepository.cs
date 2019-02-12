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
                    foreach (var show in range)
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

        public async Task<Show> GetShow(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return await session.Query<Show>().Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task DeleteShow(int id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var show = await session.GetAsync<Show>(id);

                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.DeleteAsync(show);
                    transaction.Commit();
                }
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

        public async Task EditShow(int id, string name)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var show = await session.GetAsync<Show>(id);
                Show newShow = new Show { Id = show.Id, Page = show.Page, Name = name };

                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.SaveOrUpdateAsync(newShow);
                    transaction.Commit();
                }

            }
        }

        public async Task AddShow(string name)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var lastShow = session.Query<Show>().LastOrDefault();
                Show newShow = new Show { Id = lastShow.Id + 1, Page = lastShow.Page, Name = name };

                using (ITransaction transaction = session.BeginTransaction())
                {
                    await session.SaveAsync(newShow);
                    transaction.Commit();
                }

            }
        }
    }
}