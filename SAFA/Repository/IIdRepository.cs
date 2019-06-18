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
    public interface IIdRepository : IRepository<IdProofType>
    {
    }


    
    public class IdRepository : Repository<IdProofType>, IIdRepository
    {
        public IQueryable<IdProofType> Read()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
            //return ReadAll().Where(m => m.CreatedBy == current);
            return ReadAll();
        }
    }
}