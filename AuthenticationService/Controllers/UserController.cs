using AuthenticationService.Models;
using AuthenticationService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;
        
        public UserController(ILogger logger, IMapper mapper, IUserRepository repo)
        {
            _logger = logger;
            _mapper = mapper;
            _repo = repo;

            _logger.WriteEvent($"[{DateTime.Now}]: Сообщение о событии в программе");
            _logger.WriteError($"[{DateTime.Now}]: Сообщение об ошибке в программе");
        }

        [HttpGet]
        public User GetUser()
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Login = "ostap",
                Password = "12345678",
                FirstName = "Остап",
                LastName = "Бендер",
                Email = "bender@gmail.com"
            };
        }

        [HttpGet]
        [Route("viewmodel")]
        public UserViewModel GetUserViewModel()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Login = "ostap",
                Password = "12345678",
                FirstName = "Остап",
                LastName = "Бендер",
                Email = "bender@gmail.com"
            };

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }
    }
}
