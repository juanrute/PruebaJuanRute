using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EntityCode;

namespace FraudTransactionsJuanRute.Business
{
    public class RecalculateBalance
    {
        public Transaction FillTransaction(Transaction t) {
            t.NewbalanceOrig = t.OldbalanceOrg - t.Amount;
            t.NewBalanceDest = t.OldBalanceDest + t.Amount;
            return t;
        }
    }
}