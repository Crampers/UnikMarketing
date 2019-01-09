using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnikMarketing.Domain;

namespace UnikMarketing.Business
{
    public class UserService : IUserService
    {
        private readonly MarketingContext _context;

        public UserService(MarketingContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user); //TODO: Test if called on not existing user if it still works
            await _context.SaveChangesAsync();

            return user;
        }

        public Task<User> UpdateCriteria(User user, Criteria criteria)
        {
            user.Criteria = criteria;
            _context.Users.Update(user);
            throw new NotImplementedException();
        }

        public Task<User> AddRequest(User user, Request request)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
