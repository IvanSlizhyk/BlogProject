using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DALInterfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void PreSave();
    }
}
