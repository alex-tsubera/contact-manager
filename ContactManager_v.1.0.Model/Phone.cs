using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ContactManager_v._1._0.Model
{
    public class Phone
    {
        public int PhoneID { get; set; }
        [Required]
        public int PersonID { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string Number { get; set; }

        public virtual Person Person { get; set; }
    }
}
