using Model;
using Model.EntityCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FraudTransactionsJuanRute.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            Facade fc = new Facade();            
            return View(fc.GetAllTransactions());
        }

        public ActionResult CreateTX() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTX(Transaction t)
        {
            Facade fc = new Facade();
            fc.SaveTransaction(t);
            return View();
        }
    }
}