using Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.DTOs
{
    public class transactionDTO
    {
        public TransactionTypeEnum Type { get; set; }
        public decimal Amt { get; set; }
        public DateTimeOffset TransactionDateUtcOffset { get; set; }
    }
}
