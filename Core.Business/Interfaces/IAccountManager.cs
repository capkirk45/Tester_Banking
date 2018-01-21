using Core.Common.Entities;
using Core.Common.Interfaces;
using Core.DataAccess;
using System.Collections;

namespace Core.Business.Interfaces
{
    public interface IAccountManager
    {
        void RecordDeposit(Transaction t);
        void RecordWithdrawal(Transaction t);
        IEnumerable ViewTransactionHistory(IAccount account);
        decimal CheckBalance(ILedger ledger);
    }
}
