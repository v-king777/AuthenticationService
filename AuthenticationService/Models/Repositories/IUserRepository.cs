using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetByLogin(string login);
    }
}
