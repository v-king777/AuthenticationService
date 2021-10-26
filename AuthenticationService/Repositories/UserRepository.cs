using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "ostap",
                Password = "8WX!=dt55N",
                FirstName = "Остап",
                LastName = "Бендер",
                Email = "bender@gmail.com"
            });

            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "vasiliy",
                Password = "C5F6SSB!vK",
                FirstName = "Василий",
                LastName = "Тёркин",
                Email = "terkin@mail.ru"
            });

            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "gena",
                Password = "DPe5sNw!xm",
                FirstName = "Гена",
                LastName = "Букин",
                Email = "bukin@mail.ru"
            });
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetByLogin(string login)
        {
            return _users.FirstOrDefault(x => x.Login == login);
        }
    }
}
