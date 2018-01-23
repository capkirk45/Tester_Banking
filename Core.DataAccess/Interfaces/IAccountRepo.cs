using Core.Common.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Core.DataAccess.Interfaces
{
    public interface IAccountRepo
    {
        IEnumerable GetLedgerByDateRange();
        IEnumerable GetAllDebits();
        IEnumerable GetAllCredits();
        void DebitOrCreditAccount(Transaction t, out List<Transaction> ledger);

        int TransactionCount();

    }
}
