using Core.Common.Entities;
using Core.Common.Interfaces;
using Core.Common.Enums;
using Core.DataAccess.Interfaces;
using Core.DataStore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Core.DataAccess
{
    /// <summary>
    /// Purpose:  CRUD processing against Data Store
    /// </summary>
    public class AccountRepo: IAccountRepo
    {
        private List<Transaction> _transactions;
        private MasterLedger _masterLedger;
        

        public AccountRepo() { }

        public AccountRepo(List<Transaction> transactions)
        {
            _transactions = transactions;
            _masterLedger = MasterLedger.GetInstance;
        }

        public IEnumerable GetAllTransactionsByDate()
        {
            return (from qry in _transactions
                    select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public int TransactionCount()
        {
            return _transactions.Count();
        }

        public IEnumerable GetLedgerByDateRange()
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetAllDebits()
        {
            return (from qry in _transactions
                    where qry.Type == TransactionTypeEnum.Debit
                    select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public IEnumerable GetAllCredits()
        {
            return (from qry in _transactions
                    where qry.Type == TransactionTypeEnum.Credit
                    select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public void DebitOrCreditAccount(Transaction t, out List<Transaction> ledger)
        {
            ledger.Add(t);
        }
    }
}
