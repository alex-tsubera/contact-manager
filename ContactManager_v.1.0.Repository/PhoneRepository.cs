using ContactManager_v._1._0.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Repository
{
    public class PhoneRepository: GenericRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(DbContext context) : base(context) { }

        public Phone GetById(int id)
        {
            return _dbSet.Where(x => x.PhoneID == id).FirstOrDefault();
        }
    }
}
