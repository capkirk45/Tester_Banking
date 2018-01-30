using Core.Common.Interfaces;
using Core.DataStore;

namespace Core.DataAccess
{
    /// <summary>
    /// Contains Repositories used to interact with data stores
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private AccountRepository _accountRepo;
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
                if (_accountRepo == null)
                {
                    _accountRepo = new AccountRepository(this);
                }
                return _accountRepo;
            }
       }
    }
}
