using Core.Common.Enums;
using Core.Common.Interfaces;
using System;

namespace Core.Common.Entities
{
    public class Transaction: IDataEntity
    {
        public int Id { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public decimal Amt { get; set; }
        public DateTimeOffset TransactionDateUtcOffset { get; set; }
        public DateTime TransactionDate { get; set; } 
    }
}
