using DealerManagementSoftware.Repository.BaseRepo;
using SAFA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace SAFA.Repository
{
    public interface IReligiousFundRepository : IRepository<ReligiousFundType>
    {
    }

    public class ReligiousFundRepository : Repository<ReligiousFundType>, IReligiousFundRepository
    {
        public IQueryable<ReligiousFundType> Read()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
            // return ReadAll().Where(m => m.AddedBy == current);
            return ReadAll();
        }
    }
}