using Core.Common.Entities;
using System.Collections;

namespace Core.Common.Interfaces
{
    public interface ILedger
    {
        IEnumerable ViewAllTransactionsByDate();
        IEnumerable ViewDebitsByDate();
        IEnumerable ViewCreditsByDate();
        void DebitTheAccount(Transaction t);
        void CreditTheAccount(Transaction t);

    }
}
