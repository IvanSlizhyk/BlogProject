using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLInterfaces.Exceptions
{
    public class CommentServiceException : Exception
    {
        protected CommentServiceException()
        {

        }

        public CommentServiceException(string message)
            : base(message)
        {

        }

        public CommentServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
