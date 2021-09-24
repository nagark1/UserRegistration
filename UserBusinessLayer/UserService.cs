using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataAccessLayer;
using UserRegistration.Api;

namespace UserBusinessLayer
{
    public class UserService : IUserService
    {

        private const string ACMEINC = "Ame Inc.";
        private const string WIDGETSRUS = "Widgets - R - Us";
        public User GetUser(IUserParams parameters)
        {
            UserInputValidation(parameters);
            var user = new User
            {
                FirstName = parameters.FirstName,
                LastName = parameters.SurName,
                DateOfBirth = parameters.DateOfBirth,
                Email = parameters.Email
            };
            SetCreditLimit(parameters, user);
            AddToFile(user);
            return user;
        }
        private void SetCreditLimit(IUserParams parameters,User user)
        {
            var clientRepo = new ClientRepository();
            var client = clientRepo.GetById(parameters.ClientId);

            int creditLimit = GetCreditLimit(parameters);

            if (client.ClientName.Equals(ACMEINC))
            {
                user.HasCreditLimit = false;
            }
            else if (client.ClientName.Equals(WIDGETSRUS))
            {
                user.HasCreditLimit = true;
                user.CreditLimit = 2 * creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                throw new InvalidOperationException();
            }
        }

        private void AddToFile(User user)
        {
            UserDataAccess.AddUser(new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                CreditLimit = user.CreditLimit,
                HasCreditLimit = user.HasCreditLimit
            });
        }

        private static int GetCreditLimit(IUserParams parameters)
        {
            var userCreditService = new UserCreditService();
            return userCreditService.GetCreditLimit(parameters.FirstName, parameters.SurName, parameters.DateOfBirth);
        }

        private void UserInputValidation(IUserParams parameters)
        {
            var result = new User();
            DateTime now = DateTime.Now;
            int age = now.Year - parameters.DateOfBirth.Year;

            if (string.IsNullOrEmpty(parameters.FirstName))
            {
                throw new ArgumentException("Invalid FirstName");
            }
            if (string.IsNullOrEmpty(parameters.SurName))
            {
                throw new ArgumentException("Invalid SurName");
            }
            if (string.IsNullOrEmpty(parameters.Email) || !parameters.Email.Contains('@') || !parameters.Email.Contains('.'))
            {
                throw new ArgumentException("Invalid Email");
            }
            if (now.Month < parameters.DateOfBirth.Month || (now.Month == parameters.DateOfBirth.Month && now.Day < parameters.DateOfBirth.Day))
            {
                age--;
            }
            if (age < 21)
            {
                throw new ArgumentException("Age is not eligible");
            }
        }
    }
}
