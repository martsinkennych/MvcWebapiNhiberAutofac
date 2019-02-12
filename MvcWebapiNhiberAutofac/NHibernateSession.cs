using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MvcWebapiNhiberAutofac
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = Path.Combine(HttpRuntime.AppDomainAppPath, @"DAL\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var showConfigurationFile = Path.Combine(HttpRuntime.AppDomainAppPath, @"Mappings\Show.hbm.xml");
            configuration.AddFile(showConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}