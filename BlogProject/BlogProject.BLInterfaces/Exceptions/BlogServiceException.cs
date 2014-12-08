using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLInterfaces.Exceptions
{
    public class BlogServiceException : Exception
    {
        protected BlogServiceException()
        {

        }

        public BlogServiceException(string message)
            : base(message)
        {

        }

        public BlogServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
