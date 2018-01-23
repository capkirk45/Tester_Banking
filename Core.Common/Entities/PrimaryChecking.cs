using Core.Common.Interfaces;
using Core.Common.Enums;

namespace Core.Common.Entities
{
    public class PrimaryChecking : AccountBase
    {

        public PrimaryChecking() { }

        public PrimaryChecking(IAccount account)
        {
            _account = account;
        }
    }
}
