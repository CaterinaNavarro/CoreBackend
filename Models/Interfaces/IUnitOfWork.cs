using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Models.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IUserRepository Users { get; }
        Task<bool> SaveChangesAsync();
    }
}
