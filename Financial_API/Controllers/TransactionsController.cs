using Financial_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;



namespace Financial_API.Controllers
{
    [RoutePrefix("api/Transactions")]

    public class TransactionsController : ApiController
    {
        private ApiContext db = new ApiContext();

        /// <summary>
        /// Add Transaction
        /// </summary>
        /// <param name="accId"></param>
        /// <param name="bdgId"></param>
        /// <param name="ownerId"></param>
        /// <param name="amount"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddTransaction")]
        public async Task<IHttpActionResult> AddTransaction(int accId, int bdgId, string ownerId, int amount, string type)
        {
            return Ok(JsonConvert.SerializeObject(await db.AddTransaction(accId, bdgId, ownerId, amount, type)));
        }
        /// <summary>
        /// GET ALL TRANSACTIONS
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetTransaction")]
        public Task<List<Transaction>> GetTransactions()
        {
            return db.GetTransactions();
        }
        /// <summary>
        /// Get Transactions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetTransactionDetail")]
        public Task<List<Transaction>> GetTransactionDetail(int id)
        {
            return db.GetTransactinonDetail(id);
        }
        


    }
}