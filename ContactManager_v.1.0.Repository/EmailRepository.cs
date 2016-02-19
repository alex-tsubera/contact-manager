using ContactManager_v._1._0.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Repository
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        public EmailRepository(DbContext context) : base(context) { }

        public Email GetById(int id)
        {
            return _dbSet.Where(x => x.EmailID == id).FirstOrDefault();
        }
    }
}
