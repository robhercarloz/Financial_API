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
    [RoutePrefix("api/Households")]

    public class HouseholdsController : ApiController
    {
        private ApiContext db = new ApiContext();
        
        ///<summary>
        ///Add New Household
        ///</summary>
        [HttpPost]
        [Route("AddHousehold")]
        public async Task<IHttpActionResult> AddHousehold(string name, string greeting)
        {
            return Ok(JsonConvert.SerializeObject(await db.AddHousehold(name, greeting)));
        }
        ///<summary>
        ///GET A HOUSEHOLD
        /// </summary>
        [Route("GetHousehold")]
        public Task<List<Household>> GetAllDataForASpecificHousehold(int houseId)
        {
            return db.GetHousehold(houseId);
        }
        /// <summary>
        /// GET ALL HOUSEHOLDS
        /// </summary>
        [Route("GetAllHouseholds")]
        public Task<List<Household>> GetAllHouseholds()
        {
            return db.GetAllHouseholds();
        }



    }
}