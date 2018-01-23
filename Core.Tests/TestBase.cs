using System.Collections.Generic;
using Core.Common.Entities;
using Core.Common.Interfaces;
using Core.DataAccess;

namespace Core.Tests
{
    public class TestBase
    {
        private ILedger _ledger;
       
        public TestBase(ILedger ledger)
        {
            _ledger = ledger;

        }
        public TestBase() : 
            this(new AccountRepo(new List<Transaction>())) {
        }

        public ILedger Ledger { get { return _ledger; } }
    }
}
