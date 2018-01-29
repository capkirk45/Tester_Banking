using Core.Common.Entities;
using System;
using System.Collections.Generic;

namespace Core.Business.Interfaces
{
    public interface IAccountManager
    {
        void RecordDepositOrWithdrawal(Transaction t);
        List<Transaction> ViewLedgerByDateRange(DateTime fromDt, DateTime toDt);
        List<Transaction> ViewAllDeposits();
        List<Transaction> ViewAllWithdrawals();
        decimal GetAccountBalance(List<Transaction> ledger);
       
    }
}
