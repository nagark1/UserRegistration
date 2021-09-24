using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBusinessLayer
{
    interface IUserCreditService
    {
        int GetCreditLimit(string firName, string surName, DateTime dob);
    }
}
