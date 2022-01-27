using ReadingIsGood.Core.DBEntities.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.DBEntities
{
    public class Customer : BaseEntity
    {
        //[Required(ErrorMessage = "Name is required")]
        [MaxLength(500)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [MaxLength(500)]
        public string Password { get; set; }

        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[MaxLength(500)]
        //[Compare("Password")]
        //[NotMapped]
        //public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "DOB is required")]
        //public DateTime DOB { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        
        [MaxLength(200)]
        public string ApplicationUserId { get; set; }
    }
}
