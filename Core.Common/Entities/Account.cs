using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Entities
{
    public class Account : IDataEntity
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public IEnumerable<Transaction> TransactionHistory { get; set; }

    }
}
