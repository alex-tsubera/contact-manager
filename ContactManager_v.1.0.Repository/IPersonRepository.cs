using ContactManager_v._1._0.Model;

namespace ContactManager_v._1._0.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person GetById(long id);
    }
}
