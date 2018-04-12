using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FraudTransactionsJuanRute.Controllers
{
    public class TxTypeController : Controller
    {
        private readonly IFacade fc;

        public TxTypeController(IFacade _facade)
        {
            this.fc = _facade;
        }
        // GET: TxType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TypeList()
        {
            return PartialView(fc.GetAllTxType());
        }

        public ActionResult Name(int id)
        {
            return Content(fc.GetTxType(id));
        }
    }
}