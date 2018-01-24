namespace Core.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepo AccountRepository { get; }

    }
}
