using ContactManager_v._1._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Service
{
    public interface IEmailService : IEntityService<Email>
    {
        Email GetById(int id);
    }
}
