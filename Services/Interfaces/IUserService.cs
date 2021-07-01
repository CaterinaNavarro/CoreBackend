using CoreProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task UpdateUser(int id, User user);
        Task AddUser(User user);
        Task DeleteUser(int id);

    }
}
