using Model.ServiceStuff;
using System.Collections.Generic;
using System.Web.Http;

namespace RestAssistantService.Controllers
{
    public class AssistantController : ApiController
    {
        private readonly IFacade fc;

        // GET: api/Assistant
        public IEnumerable<TransactionContract> GetFraudTx()
        {
            return fc.SearchIsFraudTx();
        }

        // GET: api/Assistant/5
        public IEnumerable<TransactionContract> GetFraudByNameDest(string name)
        {
            return fc.SearchTxByNameDest(name);
        }

        public AssistantController()
        {
            this.fc = new Facade();

        }

    }
}
