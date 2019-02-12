using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebapiNhiberAutofac.DAL
{
    public class ShowRepository : IRepository
    {
        public void AddRange(List<Show> range)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach(var show in range)
                        session.Save(show);
                    transaction.Commit();
                }
            }
        }

        public IList<Show> GetAll()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Show>().ToList();
            }
        }

        public IList<Show> GetShowsPerPage(int page)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<Show>().Where(x => x.Page == page).ToList();
            }
        }

        public bool IfPageExists(int page)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                if (session.Query<Show>().Count() > 0)
                {
                    return session.Query<Show>().Where(x => x.Page == page).Any();
                }
                else
                    return false;
            }
        }
    }
}