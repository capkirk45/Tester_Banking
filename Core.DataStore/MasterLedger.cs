using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataStore
{
    /// <summary>
    /// Provide data persistence.  Implementation will be a generic list using Singleton pattern
    /// </summary>
    public class MasterLedger
    {
        private static MasterLedger _instance = null;
        private static readonly object mutex = new object();

        private MasterLedger(){ }

        public static MasterLedger GetInstance { get
            {
                lock (mutex)
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
    }
}
