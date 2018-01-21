using Core.Common.Entities;
using Core.Common.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IAccount
    {
        ILedger Ledger { get; set; }
        AccountTypeEnum AccountType { get; set; }
        User AccountOwner { get; set; }
    }
}
