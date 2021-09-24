using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBusinessLayer
{
    public interface IUserService
    {
        User GetUser(IUserParams parameters);
    }
}
