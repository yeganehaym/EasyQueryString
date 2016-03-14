using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyQueryString;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            EmployeesRequestBody data = Requests.GetFromQueryString<EmployeesRequestBody>();
           // EmployeesRequestBody data = Requests.GetFromQueryString<EmployeesRequestBody>(RequestType.POST);
            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}