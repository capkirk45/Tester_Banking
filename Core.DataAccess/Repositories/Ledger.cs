using Core.Common;
using Core.Common.Entities;
using Core.Common.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.DataAccess
{
    public class Ledger: IDataEntity, ILedger
    {
        public List<Transaction> _transactions;

        public Ledger(List<Transaction> transactions)
        {
            _transactions = transactions;
        }

        public IEnumerable ViewAllTransactionsByDate()
        {
            return (from qry in _transactions
                    select qry).OrderBy(t => t.TransactionDate).ToList();
        }
        public IEnumerable ViewDebitsByDate()
        {
            return (from qry in _transactions
                    where qry.Type == TransactionTypeEnum.Debit
                    select qry).OrderBy(t => t.TransactionDate).ToList(); 
        }

        public IEnumerable ViewCreditsByDate()
        {
            return (from qry in _transactions
                    where qry.Type == TransactionTypeEnum.Credit
                    select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public void CreateDebit(Transaction t)
        {
            _transactions.Add(t);
        }

        public void CreateCredit(Transaction t)
        {
            _transactions.Add(t);
        }
    }
}
