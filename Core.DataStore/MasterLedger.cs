using System.Collections.Generic;
using Banking.Core.Common.Entities;

namespace Banking.Core.DataStore
{
    /// <summary>
    /// In-memory data store, taking place of a database.  
    /// Implementation will be a generic list using Singleton pattern
    /// </summary>
    public class MasterLedger
    {
        private static MasterLedger _instance = null;
        private static readonly object _mutex = new object();
        private List<Transaction> _ledger;

        private MasterLedger(){ }

        public static MasterLedger GetInstance
        {
            get
            {
                lock (_mutex)
                {
                    if (_instance == null)
                    {
                        return new MasterLedger();
                    }
                    else
                    {
                        return _instance;
                    }
                }
            }
        }

        public List<Transaction> Ledger { get { return _ledger; } }

        public void SetLedger()
        {
            if (_ledger == null)
            {
                _ledger = new List<Transaction>();
            }
        }
    }
}
