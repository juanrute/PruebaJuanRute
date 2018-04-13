using Model.EntityCode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ServiceStuff
{
    public class Facade : IFacade
    {
        public int SaveTransaction(TransactionContract t)
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                Transaction temp = new Transaction();
                temp.IdTxTypeFK = t.IdTxTypeFK;
                temp.IsFraud = t.IsFraud;
                temp.NameDest = t.NameDest;
                temp.NameOrig = t.NameOrig;
                temp.NewBalanceDest = t.NewBalanceDest;
                temp.NewbalanceOrig = t.NewbalanceOrig;
                temp.OldBalanceDest = t.OldbalanceDest;
                temp.OldbalanceOrg = t.OldbalanceOrg;
                temp.Step = t.Step;
                temp.TransactionDate = DateTime.Now;
                db.Transactions.Add(temp);
                db.SaveChanges();
                return 0;
            }
        }

        public List<TransactionContract> SearchByTxDate(DateTime dFrom, DateTime dTo)
        {
            throw new NotImplementedException();
        }

        public List<TransactionContract> SearchIsFraudTx()
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                List<TransactionContract> list = db.Database.SqlQuery<TransactionContract>("exec TransactionsSp @type,@name,@dateFrom,@dateTo", new SqlParameter("@type", "1"), new SqlParameter("@name", ""), new SqlParameter("@dateFrom", ""), new SqlParameter("@dateTo", "")).ToList();
                return list;
            }
        }

        public List<TransactionContract> SearchTxByNameDest(string name)
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                List<TransactionContract> list = db.Database.SqlQuery<TransactionContract>("exec TransactionsSp @type,@name,@dateFrom,@dateTo", new SqlParameter("@type", "2"), new SqlParameter("@name", name), new SqlParameter("@dateFrom", ""), new SqlParameter("@dateTo", "")).ToList();
                return list;
            }
        }
    }
}
