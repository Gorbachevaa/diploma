using System;
using System.Collections.Generic;
using Models;

namespace DataAccessLayer.Core.Repositories
{
    public interface IGoTermRepository : IRepository<GoTerm>
    {
        /// <summary>
        /// Gets top elements.
        /// </summary>
        /// <param name="count">Amount of required elements</param>
        /// <returns>List of elements.</returns>
        IEnumerable<GoTerm> GetTopTerms(int count);
        IEnumerable<GoTerm> GetById(int Id);
    }
}
