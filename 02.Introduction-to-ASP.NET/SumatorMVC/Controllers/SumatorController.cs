using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SumatorMVC.Controllers
{
    public class SumatorController : Controller
    {
        // GET: /Sumator/Sumator?a=2&b=3
        public ActionResult Sumator(int a, int b)
        {
            int sum = a + b;
            ViewBag.Sum = sum.ToString();

            return View();
        }

        // GET: Sumator
        public ActionResult Index()
        {
            return View();
        }
    }
}