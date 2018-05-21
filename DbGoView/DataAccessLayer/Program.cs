using System;
//using System.Collections.Generic;
//using System.Linq;
//using Models;
using DataAccessLayer.Persistance;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOWork(new GoDBContext()))
            {
                var goTerm = unitOfWork.GoTerms.Get(1);
                Console.WriteLine(goTerm.GO_ID);
                ///
                var goTerms = unitOfWork.GoTerms.GetTopTerms(10);
                foreach (var term in goTerms)
                {
                    Console.WriteLine(term.GO_ID);
                }
            }
        }
    }
}
