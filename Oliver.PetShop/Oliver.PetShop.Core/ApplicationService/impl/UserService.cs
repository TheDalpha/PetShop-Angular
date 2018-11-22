using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oliver.PetShop.Core.DomainService;
using Oliver.PetShop.Core.Entity;

namespace Oliver.PetShop.Core.ApplicationService.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepo.AddUser(user);
        }

        public void EditUser(User user)
        {
            _userRepo.EditUser(user);
        }

        public User Get(long id)
        {
            return _userRepo.Get(id);
        }

        public List<User> GetUsers()
        {
            return _userRepo.GetUsers().ToList(); ;
        }

        public void RemoveUser(long id)
        {
            _userRepo.RemoveUser(id);
        }
    }
}
