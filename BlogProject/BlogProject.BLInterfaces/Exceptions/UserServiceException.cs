using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLInterfaces.Exceptions
{
    public class UserServiceException : Exception
    {
        protected UserServiceException()
        {

        }

        public UserServiceException(string message)
            : base(message)
        {

        }

        public UserServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
