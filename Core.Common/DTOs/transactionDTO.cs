using Banking.Core.Common.Enums;
using System;

namespace Banking.Core.Common.DTOs
{
    public class transactionDTO
    {
        public TransactionTypeEnum Type { get; set; }
        public decimal Amt { get; set; }
        public DateTimeOffset TransactionDateUtcOffset { get; set; }
    }
}
