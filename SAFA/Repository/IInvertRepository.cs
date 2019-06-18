using SAFA.Repository.BaseRepo;
using SAFA.Models;
using SAFA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace SAFA.Repository
{
    public interface IInvertRepository : IRepository<InvertType>
    {
    }
    public class InvertRepository : Repository<InvertType>, IInvertRepository
    {
        public IQueryable<InvertType> Read()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
             //return ReadAll().Where(m => m.CreatedBy == current);
            return ReadAll();
        }
    }
}