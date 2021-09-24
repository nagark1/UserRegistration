using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBusinessLayer
{
    public  class UserParams : IUserParams
    {
        public UserParams(string firstName,string surName,DateTime dob, string email,int clientId)
        {
            FirstName = firstName;
            SurName = surName;
            DateOfBirth = dob;
            Email = email;
            DateOfBirth = dob;
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int ClientId { get; set; }
    }
}
