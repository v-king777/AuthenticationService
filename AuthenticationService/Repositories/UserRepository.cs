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
                Password = "12345678",
                FirstName = "Остап",
                LastName = "Бендер",
                Email = "bender@gmail.com",
                Role = new Role()
                {
                    Id = 2,
                    Name = "Администратор"
                }
            });

            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "vasiliy",
                Password = "1234",
                FirstName = "Василий",
                LastName = "Тёркин",
                Email = "terkin@mail.ru",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
            });

            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Login = "gena",
                Password = "5678",
                FirstName = "Гена",
                LastName = "Букин",
                Email = "bukin@mail.ru",
                Role = new Role()
                {
                    Id = 1,
                    Name = "Пользователь"
                }
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
