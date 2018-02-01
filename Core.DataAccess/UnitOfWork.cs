using Banking.AppCore.Common.Interfaces;
using Banking.AppCore.DataStore;
using System;

namespace Banking.AppCore.DataAccess
{
    /// <summary>
    /// Contains Repositories used to interact with data stores
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AccountRepository _accountRepository;
        private MasterLedger _masterLedger;

        public UnitOfWork()
        {
            _masterLedger = MasterLedger.GetInstance;
        }

        public MasterLedger MasterLedger { get { return _masterLedger; } }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(this);
                }
                return _accountRepository;
            }
       }

        public void Dispose()
        {
            _accountRepository.Dispose();
        }
    }
}
