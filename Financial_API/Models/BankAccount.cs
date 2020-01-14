using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financial_API.Models
{
    public class BankAccount
    {
        //PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int  AccountType { get; set; }
        public float StartingBalance { get; set; }
        public float lowLevelBalance { get; set; }
        public float CurrentBalance { get; set; }
        public int HouseholdId { get; set; }
        public string OwnerId { get; set; }
    }
}