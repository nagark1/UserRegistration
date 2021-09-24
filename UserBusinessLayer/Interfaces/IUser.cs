using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBusinessLayer
{
    interface IUser
    {
         string FirstName { get; set; }
         string LastName { get; set; }
         DateTime DateOfBirth { get; set; }
         string Email { get; set; }
         bool HasCreditLimit { get; set; }
         int CreditLimit { get; set; }
    }
}
