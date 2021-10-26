using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
