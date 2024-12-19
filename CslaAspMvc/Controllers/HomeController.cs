using Csla;
using CslaAspMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CslaAspMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataPortal<PersonEdit> _personPortal;
        private readonly ApplicationContext ApplicationContext;

        public HomeController(IDataPortal<PersonEdit> personPortal, ApplicationContext applicationContext)
        {
            _personPortal = personPortal;
            ApplicationContext = applicationContext;
        }

        public async Task<ActionResult> Index()
        {
            var contextManager = ApplicationContext.ContextManager;
            var person = await _personPortal.CreateAsync("Rocky");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}