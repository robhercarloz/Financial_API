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
    [RoutePrefix("api/Accounts")]

    public class BankAccountsController : ApiController
    {
        private ApiContext db = new ApiContext();
        /// <summary>
        /// Add ZNew Bank Account
        /// </summary>
        /// <param name="House Id"></param>
        /// <param name="Name"></param>
        /// <param name="Starting Balance "></param>
        /// <param name="Low Level Balance"></param>
        /// <param name="Current Balance"></param>
        /// <param name="Owner Id"></param>
        /// <param name="Account Type"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBankAccount")]
        public async Task<IHttpActionResult> AddBankAccount(int HouseId, string name, float startingBalance, float lowLevelBalance, float currentBalance , string ownerId, int accountType)
        {
            return Ok(JsonConvert.SerializeObject(await db.AddBankAccount(HouseId, ownerId, accountType,name, startingBalance, lowLevelBalance, currentBalance)));
        }

        ///<summary>
        ///Get bank accounts
        /// </summary>
        [Route("GetAllAccounts")]
        public Task<List<BankAccount>> GetAccounts()
        {
            return db.AllAccounts();
        }

        ///<summary>
        ///Get Bank Account Details
        /// </summary>
        [Route("GetAccountDetails")]
        public Task<List<BankAccount>> GetAccountDetails(int accId)
        {
            return db.GetAccountDetails(accId);
        }
    }
}