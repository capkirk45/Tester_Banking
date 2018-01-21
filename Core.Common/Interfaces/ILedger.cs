using Core.Common.Entities;
using System.Collections;

namespace Core.Common.Interfaces
{
    public interface ILedger
    {
        IEnumerable ViewAllTransactionsByDate();
        IEnumerable ViewDebitsByDate();
        IEnumerable ViewCreditsByDate();
        void CreateDebit(Transaction t);
        void CreateCredit(Transaction t);

    }
}
