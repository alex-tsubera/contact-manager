using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ContactManager_v._1._0.Model
{
    public class Email
    {
        public int EmailID { get; set; }
        [Required]
        public int PersonID { get; set; }
        [Required]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public virtual Person Person { get; set; }
    }
}
