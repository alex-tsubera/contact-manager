using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ContactManager_v._1._0.Model
{
    public class ContactsInitializer : DropCreateDatabaseIfModelChanges<ContactsContext>
    {
        protected override void Seed(ContactsContext context)
        {
            var people = new List<Person>{
                new Person() {FirstName="Alex",LastName="Tsubera"},
                new Person() {FirstName="Jan",LastName="Zybin"},
                new Person() {FirstName="George",LastName="Martin"}
            };
            people.ForEach(p => context.Contacts.Add(p));
            context.SaveChanges();
            var emails = new List<Email>(){
                new Email() {PersonID=1,EmailAddress="alex.tsubera@gmail.com"},
                new Email() {PersonID=1,EmailAddress="alexeyt.0912@gmail.com"},
                new Email() {PersonID=2,EmailAddress="jan.zybin@gmail.com"},
                new Email() {PersonID=3,EmailAddress="gg.martin@gmail.com"}
            };
            emails.ForEach(e => context.Emails.Add(e));
            var phones = new List<Phone>(){
                new Phone(){PersonID=1,Number="+380977908527"},
                new Phone(){PersonID=2,Number="+380989898998"},
                new Phone(){PersonID=3,Number="+12013333333"}
            };
            phones.ForEach(p => context.Phones.Add(p));
            context.SaveChanges();
        }
    }
}
