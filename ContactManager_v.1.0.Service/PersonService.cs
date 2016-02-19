using ContactManager_v._1._0.Model;
using ContactManager_v._1._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Service
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        IUnitOfWork _unitOfWork;
        IPersonRepository _personRepository;
        IEmailRepository _emailRepository;
        IPhoneRepository _phoneRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository, IEmailRepository emailRepository, IPhoneRepository phoneRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _emailRepository = emailRepository;
            _phoneRepository = phoneRepository;
        }

        public Person GetById(int id)
        {
            return _personRepository.GetById(id);
        }

        public void Create(Person person, Email email, Phone phone)
        {
            _personRepository.Add(person);
            _emailRepository.Add(email);
            _phoneRepository.Add(phone);
            _unitOfWork.Commit();
        }
    }
}
