using System;

namespace Banking.AppCore.Common.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IAccountRepository AccountRepository { get; }

    }
}
