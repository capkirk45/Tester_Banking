using Banking.AppCore.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.AppCore.Common.Entities
{
    public class UserClaim
    {
        public User User { get; }
        public Claim Claim { get; }
    }
}
