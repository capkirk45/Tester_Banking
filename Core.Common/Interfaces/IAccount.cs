using Banking.Core.Common.Entities;
using Banking.Core.Common.Enums;
using System.Collections.Generic;

namespace Banking.Core.Common.Interfaces
{
    public interface IAccount
    {
        IEnumerable<Transaction> Ledger { get; set; }
        AccountTypeEnum AccountType { get; set; }
        User AccountOwner { get; set; }
    }
}
