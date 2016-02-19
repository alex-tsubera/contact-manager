using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManager_v._1._0.Model;

namespace ContactManager_v._1._0.Repository
{
    public interface IEmailRepository : IGenericRepository<Email>
    {
        Email GetById(int id);
    }
}
