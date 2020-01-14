using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Financial_API.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext()

            : base("APIConnection")
        {
        }

        public ApiContext Create()
        {
            return new ApiContext();
        }

        //ACCOUNTS
        public async Task<int> AddBankAccount(int HouseId, string ownerId, int accountType, string name, float startingBalance, float lowLevelBalance, float currentBalance)
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @name, @startingBalance, @lowLevelbalance, @currentbalance, @houseId, @ownerId, @accountType",
                new SqlParameter("name", name),
                new SqlParameter("StartingBalance", startingBalance),
                new SqlParameter("lowLevelBalance", lowLevelBalance),
                new SqlParameter("CurrentBalance", currentBalance),
                new SqlParameter("houseId", HouseId),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("accountType", accountType));
        }
        //GET
        public async Task<List<BankAccount>> AllAccounts()
        {
            return await Database.SqlQuery<BankAccount>("GetAccounts").ToListAsync();
        }
        //GET
        public async Task<List<BankAccount>> GetAccountDetails(int accId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountDetails @AccountId",
                new SqlParameter("AccountId", accId)).ToListAsync();
        }

        //===========================================================================================
        //HOUSEHOLD

        //GET
        public async Task<List<Household>> GetHousehold(int hhId)
        {
            return await Database.SqlQuery<Household>("GetAllDataForASpecificHousehold @houseId",
                new SqlParameter("houseId", hhId)).ToListAsync();
        }

        public async Task<List<Household>> GetAllHouseholds()
        {
            return await Database.SqlQuery<Household>("GetAllRecordsFromHousehold").ToListAsync();
        }

        //INSERT
        public async Task<int> AddHousehold(string name, string greeting)
        {
            return Database.ExecuteSqlCommand("AddHousehold @name, @greeting",
                new SqlParameter("name", name),
                new SqlParameter("greeting", greeting));
        }

        //UPDATE
        public int UpdateHousehold(int id, string name, string greeting)
        {
            return Database.ExecuteSqlCommand("UpdateHousehold @id, @name, @greeting",
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("greeting", greeting));
        }

        //===========================================================================================
        //TRANSACTION
        public async Task<int> AddTransaction(int accId, int budget, string OwnerId, float Amount, string type)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @AccountId, @BudgetItemId, @OwnerId, @Amount, @Type",
                    new SqlParameter("AccountId", accId),
                    new SqlParameter("BudgetItemId", budget),
                    new SqlParameter("OwnerId", OwnerId),
                    new SqlParameter("Amount", Amount),
                    new SqlParameter("Type", type));
        }

        //GET
        public async Task<List<Transaction>> GetTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetTransaction").ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactinonDetail(int Id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetail @id",
                new SqlParameter("id", Id)).ToListAsync();
        }



        //========================================================================================
        //BUDGETS

        public async Task<int> AddBudget(int id, int ownerId, string name)
        {
            return Database.ExecuteSqlCommand("AddBudget @hhId, @ownerId, @name",
                new SqlParameter("hhId", id),
                new SqlParameter("ownerid", ownerId),
                new SqlParameter("name", name));
        }
        //GET
        public async Task<List<Budget>> GetAllBudgets()
        {
            return await Database.SqlQuery<Budget>("GetBudgets").ToListAsync();
        }

        public async Task<List<Budget>> GetBudgetDetail(int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetail @id",
                new SqlParameter("id", budgetId)).ToListAsync();
        }


        //==========================================================================================
        //BUDGET ITEMS

        //GET
        public async Task<List<BudgetItem>> GetAllBudgetItems()
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails").ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDetails(int Id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetail @bdgIid",
                new SqlParameter("@bdgIid", Id)).FirstOrDefaultAsync();
        }


    }

}