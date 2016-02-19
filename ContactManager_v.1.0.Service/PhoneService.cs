using ContactManager_v._1._0.Model;
using ContactManager_v._1._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Service
{
    public class PhoneService : EntityService<Phone>, IPhoneService
    {
        IUnitOfWork _unitOfWork;
        IPhoneRepository _phoneRepository;

        public PhoneService(IUnitOfWork unitOfWork, IPhoneRepository phoneRepository)
            : base(unitOfWork, phoneRepository)
        {
            _unitOfWork = unitOfWork;
            _phoneRepository = phoneRepository;
        }

        public Phone GetById(int id)
        {
            return _phoneRepository.GetById(id);
        }
    }
}
