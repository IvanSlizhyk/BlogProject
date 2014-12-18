using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace BlogProject.BLInterfaces.BLLInterfaces
{
    public interface IUserService : IService
    {
        string GetNameById(int userId);
        int GetUserId(HttpContext context);
    }
}
