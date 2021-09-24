using Microsoft.AspNetCore.Mvc;
using System;
using UserDataAccessLayer;
using UserBusinessLayer;

namespace UserRegistration.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [MapToApiVersion("1.0")]
        public User Post(string firName, string surName, DateTime dob, string email, int clientId)
        {
            try
            {
                var userParams = new UserParams(firName, surName, dob, email, clientId);
                var userBusinessService = new UserService();
                var userFromBusiness = userBusinessService.GetUser(userParams);
                var user = new User
                {
                    FirstName = userFromBusiness.FirstName,
                    LastName = userFromBusiness.LastName,
                    Email = userFromBusiness.Email,
                    DateOfBirth = userFromBusiness.DateOfBirth,
                    CreditLimit = userFromBusiness.CreditLimit,
                    HasCreditLimit = userFromBusiness.HasCreditLimit
                };
                return user;
            }
            catch(Exception ex)
            {
                //LOGGING
                throw new Exception(ex.Message);
            }
        }
    }
}
