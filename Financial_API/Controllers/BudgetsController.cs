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
    [RoutePrefix("api/Budgets")]
    public class BudgetsController : ApiController
    {
        private ApiContext db = new ApiContext();

        /// <summary>
        /// All Budgets
        /// </summary>
        /// <param name="id"></param>        
        [Route("GetBudgets")]
        public Task<List<Budget>> GetBudgets()
        {
            return db.GetAllBudgets();
        }
        ///<summary>
        ///GET BUDGET DETAILS
        /// </summary>
        [Route("GetBudgetsDetails")]
        public Task<List<Budget>> GetBudgetDetails(int id)
        {
            return db.GetBudgetDetail(id);
        }

        [HttpPost]
        [Route("AddBudgets")]
        public async Task<IHttpActionResult> AddBudget(int id, int ownerId, string name)
        {
            return Ok(JsonConvert.SerializeObject(await db.AddBudget(id,ownerId,name)));
        }




    }
}