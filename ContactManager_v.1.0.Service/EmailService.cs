using ContactManager_v._1._0.Model;
using ContactManager_v._1._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager_v._1._0.Service
{
    public class EmailService: EntityService<Email>, IEmailService
    {
        IUnitOfWork _unitOfWork;
        IEmailRepository _emailRepository;

        public EmailService(IUnitOfWork unitOfWork, IEmailRepository emailRepository)
            : base(unitOfWork, emailRepository)
        {
            _unitOfWork = unitOfWork;
            _emailRepository = emailRepository;
        }

        public Email GetById(int id)
        {
            return _emailRepository.GetById(id);
        }
    }
}
