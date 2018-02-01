using Banking.AppCore.Common.Interfaces;

namespace Banking.AppCore.Common.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
