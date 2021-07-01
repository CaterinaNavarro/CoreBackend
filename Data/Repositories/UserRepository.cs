using CoreProject.Data;
using CoreProject.Models.Entities;
using CoreProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CoreProjectContext context) : base(context)
        {
        }
    }
}