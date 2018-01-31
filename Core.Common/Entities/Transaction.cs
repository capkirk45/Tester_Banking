using Banking.Core.Common.Enums;
using Banking.Core.Common.Interfaces;
using System;

namespace Banking.Core.Common.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public decimal Amt { get; set; }
        public DateTimeOffset TransactionDateUtcOffset { get; set; }
        public DateTime TransactionDate { get; set; } 
    }
}
