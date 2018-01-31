namespace Banking.Core.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }

    }
}
