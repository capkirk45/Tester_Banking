using Core.Common.Enums;
using Core.Common.Interfaces;
using System.Collections.Generic;

namespace Core.Common.Entities
{
    public class AccountBase: IAccount
    {
        private IEnumerable<Transaction> _ledger;

        public string Name { get; set; }
        public decimal Balance { get; set; }

        public AccountTypeEnum AccountType { get; set; }

        public User AccountOwner { get; set; }

        public IEnumerable<Transaction> Ledger
        {
            get { return _ledger; }
            set { _ledger = value; }
        }
    }
}
