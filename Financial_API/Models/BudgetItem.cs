using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financial_API.Models
{
    public class BudgetItem
    {
        //PROPERTIES
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public DateTime Created { get; set; }
        public string BudgetName { get; set; }
        public float TargetAmount { get; set; }
        public float CurrentAmount { get; set; }
    }
}