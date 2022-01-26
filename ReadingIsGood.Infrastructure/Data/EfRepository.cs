using ReadingIsGood.Core.Data;
using ReadingIsGood.Core.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadingIsGood.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : BaseEntity
    {
        public EfRepository(ReadingIsGoodDBContext dbContext) : base(dbContext)
        {

        }
    }
}
