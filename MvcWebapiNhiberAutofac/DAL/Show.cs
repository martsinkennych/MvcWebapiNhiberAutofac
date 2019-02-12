using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebapiNhiberAutofac.DAL
{
    public class Show
    {
        public virtual int Id { get; set; }
        public virtual int Page { get; set; }
        public virtual string Name { get; set; }
    }
}