using Banking.AppCore.Common.Entities;
using Banking.AppCore.Common.Enums;
using System.Collections.Generic;

namespace Banking.AppCore.Common.Interfaces
{
    public interface IAccount
    {
        IEnumerable<Transaction> Ledger { get; set; }
        AccountTypeEnum AccountType { get; set; }
        User AccountOwner { get; set; }
    }
}
