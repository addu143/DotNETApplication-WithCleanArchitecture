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
        [MaxLength(500)]
        public string Name { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        
        [MaxLength(200)]
        public string ApplicationUserId { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
