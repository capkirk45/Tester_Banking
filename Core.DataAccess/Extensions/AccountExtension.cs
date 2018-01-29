using Core.Common.Entities;
using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Extensions
{
    public static class AccountExtension
    {
        public static int CreateId(this IAccount account)
        {
            return (from qry in account.Ledger select qry.Id).Max() +1;
        }

    }
}
