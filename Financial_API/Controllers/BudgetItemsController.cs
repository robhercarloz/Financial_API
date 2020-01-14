using Financial_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;



namespace Financial_API.Controllers
{
    [RoutePrefix("api/BudgetItems")]

    public class BudgetItemsController : ApiController
    {

        private ApiContext db = new ApiContext();

        ///<summary>
        ///GET ALL BUDGET ITEMS
        /// </summary>
        [Route("GetBudgetItems")]
        public Task<List<BudgetItem>> GetAllBI()
        {
            return db.GetAllBudgetItems();
        }
        ///<summary>
        ///GET BUDGET ITEM DETAILS
        /// </summary>
        [Route("GetBudgetItemDetails")]
        public Task<BudgetItem> GetBIDetails(int id)
        {
            return db.GetBudgetItemDetails(id);
        }

    }
}