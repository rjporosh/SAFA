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
    public interface IReligionRepository : IRepository<Religion>
    {
    }
    public class ReligionRepository : Repository<Religion>, IReligionRepository
    {
        public IQueryable<Religion> Read()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
            // return ReadAll().Where(m => m.AddedBy == current);
            return ReadAll();
        }
    }
}