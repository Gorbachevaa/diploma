using DataAccessLayer;
using DataAccessLayer.Core.Repositories;
using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer.Persistance.Repositories
{
    public class GoTermRepository : Repository<GoTerm>, IGoTermRepository
    {
        public GoTermRepository(GoDBContext context)
            : base(context) {}
        public IEnumerable<GoTerm> GetTopTerms(int count)
        {
            return GoDBContext.GoTerms.Take(count).ToList();
        }
        public IEnumerable<GoTerm> GetById(int Id)
        {
            return GoDBContext.GoTerms.Where(c => c.GO_ID == Id).Take(100).ToList();
        }
        public GoDBContext GoDBContext
        {
            get { return Context as GoDBContext; }
        }
    }
}
