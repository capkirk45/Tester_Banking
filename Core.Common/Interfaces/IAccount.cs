using Core.Common.Entities;
using Core.Common.Enums;
using System.Collections.Generic;

namespace Core.Common.Interfaces
{
    public interface IAccount
    {
        List<Transaction> Ledger { get; set; }
        AccountTypeEnum AccountType { get; set; }
        User AccountOwner { get; set; }
    }
}
