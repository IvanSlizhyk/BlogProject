using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using BlogProject.BLInterfaces.BLLInterfaces;
using BlogProject.DALInterfaces;

namespace BlogProject.Services.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
            : base(unitOfWork, repositoryFactory)
        {
        }

        public string GetNameById(int userId)
        {
            return "Hello world!";
        }

        public int GetUserId(HttpContext context)
        {
            /*var userName = context.User.Identity.Name;
            var user = Membership.GetUser(userName);
            if (user != null)
            {
                return (Guid)user.ProviderUserKey;
                
            }
            return Guid.Empty;*/
            return 0;
        }
    }
}
