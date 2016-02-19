using ContactManager_v._1._0.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(int id);
        void Create(Person person, Email email, Phone phone);
    }
}
