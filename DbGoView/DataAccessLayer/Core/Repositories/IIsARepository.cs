using System;
using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Core.Repositories
{
    public interface IIsARepository : IRepository<is_a>
    {
        IEnumerable<is_a> GetTopIsAs(int count);
    }
}
