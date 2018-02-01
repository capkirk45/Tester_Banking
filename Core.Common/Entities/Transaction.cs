using System;

namespace Banking.AppCore.Common.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Amt { get; set; }
        public DateTimeOffset TransactionDateUtcOffset { get; set; }
        public DateTime TransactionDate { get; set; } 
    }
}
