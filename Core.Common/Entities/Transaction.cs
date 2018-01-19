using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Entities
{
    public class Transaction: IDataEntity
    {
        public int Id { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public decimal TransactionAmt { get; set; }
        DateTimeOffset TransactionDateUtcOffset { get; set; }
        DateTime TransactionDate { get; set; } 
    }
}
