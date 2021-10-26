using AuthenticationService.Models;
using AuthenticationService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
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

        [Authorize]
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

        
        [HttpPost]
        [Route("authenticate")]
        public async Task<UserViewModel> Authenticate(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Запрос не корректен");
            }

            User user = _repo.GetByLogin(login);

            if (user is null)
            {
                throw new AuthenticationException("Пользователь не найден");
            }

            if (user.Password != password)
            {
                throw new AuthenticationException("Введён неверный пароль");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AppCookie", 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
