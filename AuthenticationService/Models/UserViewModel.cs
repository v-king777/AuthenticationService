using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuthenticationService.Models
{
    public class UserViewModel
    {
        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.FirstName, user.LastName);
            FromRussia = GetFromRussiaValue(user.Email);
        }

        public Guid Id { get; set; }

        public string FullName { get; set; }

        public bool FromRussia { get; set; }

        private string GetFullName(string firstName, string lastName)
        {
            return String.Concat(firstName, " ", lastName);
        }

        private bool GetFromRussiaValue(string email)
        {
            var mailAddress = new MailAddress(email);

            if (mailAddress.Host.Contains(".ru"))
            {
                return true;
            }
                
            return false;
        }
    }
}
