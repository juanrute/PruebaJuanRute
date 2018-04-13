using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ServiceStuff
{
    public interface IFacade
    {
        int SaveTransaction(TransactionContract t);
        List<TransactionContract> SearchTxByNameDest(string name);
        List<TransactionContract> SearchIsFraudTx();
        List<TransactionContract> SearchByTxDate(DateTime dFrom, DateTime dTo);
    }
}
