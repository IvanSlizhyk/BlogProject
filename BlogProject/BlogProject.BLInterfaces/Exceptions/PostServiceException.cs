using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLInterfaces.Exceptions
{
    public class PostServiceException : Exception
    {
        protected PostServiceException()
        {

        }

        public PostServiceException(string message)
            : base(message)
        {

        }

        public PostServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
