using Core.Common.Enums;
using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Entities
{
    public class AccountBase: IDataEntity, IAccount
    {
        internal IAccount _account;

        public string Name { get; set; }
        public decimal Balance { get; set; }

        public AccountTypeEnum AccountType { get; set; }

        public User AccountOwner { get; set; }

        public List<Transaction> Ledger
        {
            get { return _account.Ledger; }
            set
            {
                if (_account.Ledger == null)
                {
                    _account.Ledger = new List<Transaction>();
                }
                _account.Ledger = value;
            }
        }
    }
}
