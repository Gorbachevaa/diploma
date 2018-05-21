using System;
using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Core.Repositories
{
    public interface IPartOfRepository : IRepository<part_of>
    {
        IEnumerable<part_of> GetTopPartOfs(int count);
    }
}
