using Banking.AppCore.Common.Entities;
using System;
using System.Collections.Generic;

namespace Banking.AppCore.Common.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Transaction> GetLedgerByDateRange(DateTime fromDt, DateTime toDt);
        IEnumerable<Transaction> GetAllDebits();
        IEnumerable<Transaction> GetAllCredits();
        void DebitOrCreditAccount(Transaction t);
        int TransactionCount();
        int CreateId();
        decimal GetDebitTotalAmt();
        decimal GetCreditTotalAmt();

    }
}
