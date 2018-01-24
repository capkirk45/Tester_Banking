using Core.Common.Interfaces;
using Core.DataStore;

namespace Core.DataAccess
{
    /// <summary>
    /// Contains Repositories used to interact with data stores
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private AccountRepo _accountRepo;
        private MasterLedger _masterLedger;

        public UnitOfWork()
        {
            _masterLedger = MasterLedger.GetInstance;
        }

        public MasterLedger MasterLedger { get { return _masterLedger; } }

        public IAccountRepo AccountRepository
        {
            get
            {
                if (_accountRepo == null)
                {
                    _accountRepo = new AccountRepo(this);
                }
                return _accountRepo;
            }
       }
    }
}
