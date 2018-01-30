using Core.Common.Entities;
using System;
using System.Collections.Generic;

namespace Core.Business.Interfaces
{
    public interface IAccountManager
    {
        void RecordDepositOrWithdrawal(Transaction t);
        IEnumerable<Transaction> ViewLedgerByDateRange(DateTime fromDt, DateTime toDt);
        IEnumerable<Transaction> ViewAllDeposits();
        IEnumerable<Transaction> ViewAllWithdrawals();
        decimal GetAccountBalance(IEnumerable<Transaction> ledger);
       
    }
}
