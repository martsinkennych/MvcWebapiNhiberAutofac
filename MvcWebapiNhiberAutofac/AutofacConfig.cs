﻿using Autofac;
using Autofac.Integration.Mvc;
using MvcWebapiNhiberAutofac.BL;
using MvcWebapiNhiberAutofac.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebapiNhiberAutofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<ShowRepository>().As<IRepository>();
            builder.RegisterType<ShowService>().As<IShowService>();
            builder.RegisterType<ScraperService>().As<IScraperService>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}