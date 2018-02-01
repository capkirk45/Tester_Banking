using Banking.AppCore.Common.Enums;
using Banking.AppCore.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.AppCore.Common.Entities
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public ClaimTypeEnum ClaimType { get; set; }

    }
}
