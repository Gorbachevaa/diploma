using DataAccessLayer;
using DataAccessLayer.Core.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Persistance.Repositories
{
    public class IsARepository : Repository<is_a>, IIsARepository
    {
        public IsARepository(GoDBContext context)
            : base(context) { }
        public IEnumerable<is_a> GetTopIsAs(int count)
        {
            return GoDBContext.is_a.Take(count).ToList();
        }
        public GoDBContext GoDBContext
        {
            get { return Context as GoDBContext; }
        }
    }
}
