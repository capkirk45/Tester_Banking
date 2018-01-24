using Core.Common.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Common.Interfaces
{
    public interface IAccountRepo
    {
        List<Transaction> GetLedgerByDateRange(DateTime fromDt, DateTime toDt);
        List<Transaction> GetAllDebits();
        List<Transaction> GetAllCredits();
        void DebitOrCreditAccount(Transaction t);

        int TransactionCount();

    }
}
