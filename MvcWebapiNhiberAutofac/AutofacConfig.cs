using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MvcWebapiNhiberAutofac.BL;
using MvcWebapiNhiberAutofac.DAL;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcWebapiNhiberAutofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллеры в текущей сборке
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // регистрируем споставление типов
            builder.RegisterType<ShowRepository>().As<IRepository>();
            builder.RegisterType<ShowService>().As<IShowService>();
            builder.RegisterType<ScraperService>().As<IScraperService>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}