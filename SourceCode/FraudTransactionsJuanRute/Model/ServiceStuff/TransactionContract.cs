using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ServiceStuff
{
    public class TransactionContract
    {
        public int Id { get; set; }
        public int Step { get; set; }
        public int IdTxTypeFK { get; set; }
        public String NameOrig { get; set; }
        public decimal OldbalanceOrg { get; set; }
        public decimal Amount { get; set; }
        public decimal NewbalanceOrig { get; set; }
        public decimal NewBalanceDest { get; set; }
        public String NameDest { get; set; }
        public decimal OldbalanceDest { get; set; }
        public DateTime TransactionDate { get; set; }
        public Boolean IsFraud { get; set; }
        public int IdType { get; set; }
        public String TransactionName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
