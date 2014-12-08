using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProject.BLInterfaces.BLLInterfaces;
using BlogProject.DALInterfaces;

namespace BlogProject.Services
{
    public abstract class BaseService : IService
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        protected IRepositoryFactory RepositoryFactory { get; set; }

        protected BaseService(IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory)
        {
            UnitOfWork = unitOfWork;
            RepositoryFactory = repositoryFactory;
        }
    }
}
