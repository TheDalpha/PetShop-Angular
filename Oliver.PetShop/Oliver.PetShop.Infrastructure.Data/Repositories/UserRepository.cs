using Microsoft.EntityFrameworkCore;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;
using Oliver.PetShop.Infrastructure.Data2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly PetShopAppContext _ctx;

        public UserRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public void AddUser(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        public void EditUser(User user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public User Get(long id)
        {
            return _ctx.Users.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _ctx.Users;
        }

        public void RemoveUser(long id)
        {
            var item = _ctx.Users.FirstOrDefault(b => b.Id == id);
            _ctx.Users.Remove(item);
            _ctx.SaveChanges();
        }
    }
}
