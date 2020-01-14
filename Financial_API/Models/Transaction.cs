using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financial_API.Models
{
    public class Transaction
    {
        //PROPERTIES
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public float Amount { get; set; }
        public string Memo { get; set; }
        public int BankAccountId { get; set; }
        public int? BudgetItemId { get; set; }
        public string OwnerId { get; set; }
    }
}