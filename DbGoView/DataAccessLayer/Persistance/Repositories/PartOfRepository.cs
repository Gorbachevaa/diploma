using DataAccessLayer.Core.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Persistance.Repositories
{
    public class PartOfRepository : Repository<part_of>, IPartOfRepository
    {
        public PartOfRepository(GoDBContext context)
            : base(context) { }
        public IEnumerable<part_of> GetTopPartOfs(int count)
        {
            return GoDBContext.part_of.Take(count).ToList();
        }
        public GoDBContext GoDBContext
        {
            get { return Context as GoDBContext; }
        }
    }
}
