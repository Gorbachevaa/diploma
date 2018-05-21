using System;
using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Core.Repositories
{
    public interface IHumanStructRepository : IRepository<HumanStruct>
    {
        IEnumerable<HumanStruct> GetTopHumanStruct(int count);
    }
}
