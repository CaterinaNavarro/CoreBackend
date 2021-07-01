using CoreProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreProject.Models.Interfaces;

namespace CoreProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreProjectContext _context;
        public UnitOfWork(CoreProjectContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public IUserRepository Users { get; private set; }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing) _context?.Dispose();

        }

        public async ValueTask DisposeAsyncCore()
        {
            if (_context is null) return;

            await _context.DisposeAsync().ConfigureAwait(false);

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }

}
