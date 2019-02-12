using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebapiNhiberAutofac.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }        
    }
    public class IndexViewModel
    {
        public IEnumerable<ShowModel> Shows { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}