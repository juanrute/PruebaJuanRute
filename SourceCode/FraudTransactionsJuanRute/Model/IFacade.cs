using Model.EntityCode;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IFacade
    {
        List<Transaction> GetAllTransactions();
        Transaction GetTransactionsById(int id);
        string GetTxType(int id);
        List<TransactionType> GetAllTxType();
        int SaveTransaction(Transaction t);
        int ChangeTransactionState(int id);
        List<Transaction> SearchTxByNameDest(string name);
        List<Transaction> SearchIsFraudTx();
        List<Transaction> SearchByTxDate(DateTime dFrom, DateTime dTo);
    }
}
