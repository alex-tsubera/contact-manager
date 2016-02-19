using ContactManager_v._1._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Repository
{
    public interface IPhoneRepository : IGenericRepository<Phone>
    {
        Phone GetById(int id);
    }
}
