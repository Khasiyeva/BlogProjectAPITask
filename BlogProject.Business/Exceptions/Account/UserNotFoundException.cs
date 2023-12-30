using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Exceptions.Account
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException() : base("Username/Email ve ya Password sehvdir.") 
        {
            
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }
    }
}
