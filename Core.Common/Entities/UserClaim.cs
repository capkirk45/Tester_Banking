﻿using Banking.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Common.Entities
{
    public class UserClaim
    {
        public User User { get; }
        public Claim Claim { get; }
    }
}
