using SAFA.Repository.BaseRepo;
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
            SBMDBEntities db = new SBMDBEntities();

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
            return ReadAll();
        }
        public List<Religion> ReadWithCB()
        {
            SBMDBEntities db = new SBMDBEntities();
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
           // Convert.ToInt32(current);
            return db.Religions.ToList();
        }
       
    }
}