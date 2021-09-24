using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBusinessLayer
{
    public interface IUserParams
    {
         string FirstName { get; set; }
         string SurName { get; set; }
         DateTime DateOfBirth { get; set; }
         string Email { get; set; }
         int ClientId { get; set; }
    }
}
