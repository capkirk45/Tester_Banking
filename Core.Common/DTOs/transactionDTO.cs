using Banking.AppCore.Common.Enums;
using System;

namespace Banking.AppCore.Common.DTOs
{
    public class TransactionDTO
    {
        public string Type { get; set; }
        public decimal Amt { get; set; }
        public DateTimeOffset TransactionDateUtcOffset { get; set; }
    }
}
