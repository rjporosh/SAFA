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
    public interface IBankRepository : IRepository<PaymentType>
    {
    }


    
    public class BankRepository : Repository<PaymentType>, IBankRepository
    {
        public IQueryable<PaymentType> Read()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string current = (identity.Identity.Name).Split('&')[0];
            //return ReadAll().Where(m => m.CreatedBy == current);
            return ReadAll();
        }
    }
   
}