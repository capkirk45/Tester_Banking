using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections;
using Core.Common.Enums;

namespace Core.Common.Entities
{
    public class PrimaryAccount : IDataEntity, IAccount
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public AccountTypeEnum AccountType { get; set; }
        
        public User AccountOwner { get; set; }

        public ILedger Ledger { get; set; }

    }
}
