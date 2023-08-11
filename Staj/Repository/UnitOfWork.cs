using Staj.Interfaces;
using Staj.Models;

namespace Staj.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DoorContext _context;

        public IRepository<door> DoorRepository { get; private set; }

        public UnitOfWork(DoorContext context)
        {
            _context = context;
            DoorRepository = new Repository<door>(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
