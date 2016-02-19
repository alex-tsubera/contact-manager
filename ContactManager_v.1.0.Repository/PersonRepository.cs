using ContactManager_v._1._0.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context) { }


        public Person GetById(long id)
        {
            return _dbSet.Where(x => x.PersonID == id).FirstOrDefault();
        }
    }
}
