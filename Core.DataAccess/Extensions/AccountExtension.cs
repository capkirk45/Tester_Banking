using Banking.AppCore.Common.Interfaces;
using System.Linq;

namespace Banking.AppCore.DataAccess.Extensions
{
    public static class AccountExtension
    {
        public static int CreateId(this IAccount account)
        {
            return (from qry in account.Ledger select qry.Id).Max() +1;
        }

    }
}
