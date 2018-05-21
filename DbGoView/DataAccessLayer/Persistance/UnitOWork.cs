 using DataAccessLayer.Core;
using DataAccessLayer.Core.Repositories;
using DataAccessLayer.Persistance.Repositories;
using Models;
using System;

namespace DataAccessLayer.Persistance
{
    public class UnitOWork : IUnitOfWork
    {
        private readonly GoDBContext _context;
        public UnitOWork(GoDBContext context)
        {
            _context = context;
            GoTerms = new GoTermRepository(_context);
            HumanStructs = new HumanStructRepository(_context);
            IsAs = new IsARepository(_context);
            PartOfs = new PartOfRepository(_context);
        }
        public IGoTermRepository GoTerms { get; private set; }
        public IHumanStructRepository HumanStructs { get; private set; }
        public IIsARepository IsAs { get; private set; }
        public IPartOfRepository PartOfs { get; private set; }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
