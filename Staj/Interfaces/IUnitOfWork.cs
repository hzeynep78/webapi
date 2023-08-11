using Staj.Models;
using Staj.Repository;

namespace Staj.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<door> DoorRepository { get; }
        void Save();
    }

}
