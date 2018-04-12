﻿using Model.EntityCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Facade : IFacade
    {
        public int ChangeTransactionState(Transaction t)
        {
            try
            {
                using (FinancialTXEntities db = new FinancialTXEntities())
                {
                    db.Transactions.Where(x => x.Id == t.Id).FirstOrDefault().IsFraud = !t.IsFraud ;
                    db.SaveChanges();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 1;
            }
           
        }

        public List<Transaction> GetAllTransactions() {
            using (FinancialTXEntities db=new FinancialTXEntities()) {
                return db.Transactions.ToList();
            }
        }

        public List<TransactionType> GetAllTxType()
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                return db.TransactionTypes.ToList();
            }
        }

        public string GetTxType(int id)
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                return db.TransactionTypes.Where(x => x.IdType == id).First().TransactionName;
            }
        }

        public int SaveTransaction(Transaction t)
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                db.Transactions.Add(t);
                db.SaveChanges();
                return 0;
            }
        }

        public List<Transaction> SearchByTxDate(DateTime dFrom, DateTime dTo)
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                return db.Transactions.Where(x => x.TransactionDate> dFrom&& x.TransactionDate < dTo).ToList();
            }
        }

        public List<Transaction> SearchIsFraudTx()
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                return db.Transactions.Where(x => x.IsFraud==true).ToList();
            }
        }

        public List<Transaction> SearchTxByNameDest(string name)
        {
            using (FinancialTXEntities db = new FinancialTXEntities())
            {
                return db.Transactions.Where(x => x.NameDest.Contains("name")).ToList();
            }
        }
    }
}
