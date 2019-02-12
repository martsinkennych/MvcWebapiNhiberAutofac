using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebapiNhiberAutofac.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public object Deathday { get; set; }
        public string Gender { get; set; }
    }

    public class CastModel
    {
        public Person Person { get; set; }
        public bool Self { get; set; }
    }
}