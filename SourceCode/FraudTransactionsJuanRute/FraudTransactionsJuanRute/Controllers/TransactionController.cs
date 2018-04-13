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
        private readonly IFacade fc;

        public TransactionController(IFacade _facade)
        {
            this.fc = _facade;
        }

        // GET: Transaction
        public ActionResult Index()
        {
            return View(fc.GetAllTransactions());
        }

        public ActionResult CreateTX() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTX(Transaction t)
        {
            if (!ModelState.IsValid) {
                return View();
            }
            fc.SaveTransaction(t);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) {
            return View(fc.GetTransactionsById(id));
        }

        public ActionResult Edit(int id) {
            return View(fc.GetTransactionsById(id));
        }
        [HttpPost]
        public ActionResult Edit(Transaction t)
        {
            fc.ChangeTransactionState(t.Id);
            return RedirectToAction("Index");
        }

        public ActionResult FilterName(string searching)
        {
            return View("Index",fc.SearchTxByNameDest(searching));
        }

        public ActionResult FraudOnly()
        {
            return View("Index", fc.SearchIsFraudTx());
        }

        public ActionResult FilterDate(string DateFrom, string DateTo)
        {
            return Content("fd");
            return View("Index", fc.SearchByTxDate(DateTime.Now, DateTime.Now));
        }
    }
}