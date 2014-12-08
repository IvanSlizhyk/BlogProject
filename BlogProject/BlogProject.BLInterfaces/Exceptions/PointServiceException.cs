using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLInterfaces.Exceptions
{
    public class PointServiceException : Exception
    {
        protected PointServiceException()
        {

        }

        public PointServiceException(string message)
            : base(message)
        {

        }

        public PointServiceException(Exception ex)
            : base("See inner exception", ex)
        {

        }
    }
}
