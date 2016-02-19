using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContactManager_v._1._0.Model
{
    public class ContactsContext : DbContext
    {
        public ContactsContext()
            : base("ContactsContext")
        {
        }

        public DbSet<Person> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}