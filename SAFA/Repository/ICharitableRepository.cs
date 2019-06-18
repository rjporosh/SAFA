using SAFA.Models;
using SAFA.Repository.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace SAFA.Repository
{
    public interface ICharitableRepository : IRepository<CharitableFundType>
    {
    }

  
    public class CharitableRepository : Repository<CharitableFundType>, ICharitableRepository
    {
        public IQueryable<CharitableFundType> Read()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
            //return ReadAll().Where(m => m.CreatedBy == current);
            return ReadAll();
        }
    }
}