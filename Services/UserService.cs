using CoreProject.Models.Entities;
using CoreProject.Models.Exceptions;
using CoreProject.Models.Interfaces;
using CoreProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUser(User user)
        {

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                throw new ItemNotFoundException("The user ID you entered does not exists.");
            }
            
            _unitOfWork.Users.Remove(user);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                throw new ItemNotFoundException("The user ID you entered does not exists.");
            }
            
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _unitOfWork.Users.GetAll().ToListAsync();
        }

        public async Task UpdateUser(int id, User user)
        {

            var userToUpdate = await _unitOfWork.Users.GetByIdAsync(id);

            if (userToUpdate == null)
            {
                throw new ItemNotFoundException("The user ID you entered does not exists.");
            }

            user.UserId = id;
            await _unitOfWork.Users.Update(id, user);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
