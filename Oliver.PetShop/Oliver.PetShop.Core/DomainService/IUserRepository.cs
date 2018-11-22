using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User Get(long id);

        void AddUser(User user);

        void EditUser(User user);

        void RemoveUser(long id);
    }
}
