using Core.Common.Enums;
using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Entities
{
    public class Claim: IDataEntity
    {
        public int ClaimId { get; set; }
        public ClaimTypeEnum ClaimType { get; set; }

    }
}
