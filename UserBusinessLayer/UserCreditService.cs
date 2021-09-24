using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBusinessLayer
{
    public class UserCreditService :IUserCreditService
    {
        private static readonly List<(string FirstName, string LastName, int CreditLimit)> data 
            = new List<(string FirstName, string LastName, int CreditLimit)>()
        {
            ("John Q.", "Public", 1000),
            ("Sally", "McSally", 750),
            ("John", "Doe", 350)
        };

        //YOU MAY NOT CHANGE THIS FUNCTION DECLARATION OR ITS CONTENTS
        //The purpose of this function is to simulate doing a credit lookup and calculating a credit limit.
        public int GetCreditLimit(string firName, string surName, DateTime dob)
        {
            var person = getPersonByName(firName, surName);

            if (person != default)
            {
                return person.CreditLimit;
            }

            if (dob >= DateTime.Now.AddYears(-21))
            {
                return 400;
            }

            return 500;
        }

        private static (string FirstName, string LastName, int CreditLimit) getPersonByName(string firName, string surName)
        {
            return data.FirstOrDefault(p => string.Compare(p.FirstName, firName, true) == 0 &&
                                                                string.Compare(p.LastName, surName, true) == 0);
        }
    }
}
