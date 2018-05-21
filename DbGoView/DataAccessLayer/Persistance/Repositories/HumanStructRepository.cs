using DataAccessLayer.Core.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Persistance.Repositories
{
    public class HumanStructRepository : Repository<HumanStruct>, IHumanStructRepository
    {
        public HumanStructRepository(GoDBContext context)
            : base(context) { }
        public IEnumerable<HumanStruct> GetTopHumanStruct(int count)
        {
            return GoDBContext.HumanStructs.Take(count).ToList();
        }
        public GoDBContext GoDBContext
        {
            get { return Context as GoDBContext; }
        }
    }
}
