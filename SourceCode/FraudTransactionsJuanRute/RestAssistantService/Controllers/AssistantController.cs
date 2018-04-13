using Model.ServiceStuff;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RestAssistantService.Controllers
{
    public class AssistantController : ApiController
    {
        private readonly IFacade fc;

        // GET: api/Assistant
        /// <summary>
        /// Search is fraud transactions 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TransactionContract> GetFraudTx()
        {
            return fc.SearchIsFraudTx();
        }

        /// <summary>
        /// Search the transactions that in the attribute NameDest contain this string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        // GET: api/Assistant/5
        public IEnumerable<TransactionContract> GetFraudByNameDest(string name)
        {
            return fc.SearchTxByNameDest(name);
        }

        /// <summary>
        /// Search the transactions that be in this range of date
        /// </summary>
        /// <param name="dFrom"></param>
        /// <param name="dTo"></param>
        /// <returns></returns>
        // GET: api/Assistant/dFrom/dTo
        public IEnumerable<TransactionContract> GetFraudByDate(DateTime dFrom, DateTime dTo)
        {
            return fc.SearchByTxDate(dFrom, dTo);
        }

        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <param name="tx"></param>
        /// <returns></returns>
        // GET: api/Assistant/Object
        public int saveTx(TransactionContract tx)
        {
            return fc.SaveTransaction(tx);
        }

        public AssistantController()
        {
            this.fc = new Facade();

        }

    }
}
