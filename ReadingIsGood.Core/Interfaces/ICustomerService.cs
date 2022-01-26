using ReadingIsGood.Core.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Add();
    }
}
