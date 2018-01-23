using Core.Common.Entities;
using Core.Common.Interfaces;
using Core.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Business.Interfaces
{
    public interface IAccountManager
    {
        void CreateDepositOrCredit(Transaction t);
        List<Transaction> ViewLedgerByDateRange(DateTime fromDt, DateTime toDt);
        decimal CheckBalance(List<Transaction> ledger);
    }
}
