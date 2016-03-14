using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using EasyQueryString;

namespace WebApplication1.Models
{
    public class EmployeesRequestBody
    {
        [RequestBodyField("current")]
        public int CurrentPage { get; set; }

        [RequestBodyField("rowcount")]
        public int RowCount { get; set; }

        [RequestBodyField("searchPhrase")]
        public string SearchPhrase { get; set; }

        [RequestBodyField("sort")]
        public NameValueCollection SortDictionary { get; set; }
    }
}