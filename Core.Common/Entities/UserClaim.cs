using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Entities
{
    public class UserClaim: IDataEntity
    {
        public User User { get; }
        public Claim Claim { get; }
    }
}
