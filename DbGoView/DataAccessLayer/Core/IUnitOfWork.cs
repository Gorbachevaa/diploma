using System;
using DataAccessLayer.Core.Repositories;

namespace DataAccessLayer.Core
{
    public interface IUnitOfWork :IDisposable
    {
        IGoTermRepository GoTerms { get; }
        IHumanStructRepository HumanStructs { get; }
        IIsARepository IsAs { get;}
        IPartOfRepository PartOfs { get; }
        /// <summary>
        /// Save changes to the database.
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
