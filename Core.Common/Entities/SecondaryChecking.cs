using Core.Common.Interfaces;
using Core.Common.Enums;

namespace Core.Common.Entities
{
    public class SecondaryChecking : AccountBase
    {

        public SecondaryChecking() { }

        public SecondaryChecking(IAccount account)
        {
            _account = account;
        }


    }
}
