using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScruffyNerfHerderSabers.DAL;
using ScruffyNerfHerderSabers.ViewModels;

namespace ScruffyNerfHerderSabers.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<TransactionDateGroup> data = from customer in db.Customers
                                                    group customer by customer.TransactionDate into dateGroup
                                                    select new TransactionDateGroup()
                                                    {
                                                        TransactionDate = dateGroup.Key,
                                                        CustomerCount = dateGroup.Count()
                                                    };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}