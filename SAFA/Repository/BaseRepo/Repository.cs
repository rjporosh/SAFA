using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SAFA.Models;
using System.Security.Claims;
using System.Threading;
using SAFA.Auth;
using System.Security.Principal;

namespace SAFA.Repository.BaseRepo
{
    public class Repository<T> : IRepository<T>
        where T : class
       
    {
       public SBMDBEntities db = new SBMDBEntities();
        public int Add(T entity)
        {
            var CreatedBy = entity.GetType().GetProperty("CreatedBy");
            var CreatedDate = entity.GetType().GetProperty("CreatedDate");
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            // string[] current = (identity.Identity.Name).Split('&');
            ////string[] current = (identity.Identity.Name).Split('&');
            ////Convert.ToInt32(current);
            //CreatedBy.SetValue(entity, current[0],null);
            CreatedDate.SetValue(entity, DateTime.Now, null);
            db.Set<T>().Add(entity);

           return db.SaveChanges();
        }

        public int AddRange( List<T> entityList)
        {
            db.Set<T>().AddRange(entityList);


           return db.SaveChanges();
        }

        public int Delete(T entity)
        {
            db.Set<T>().Remove(entity);

           return db.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return db.Set<T>().AsQueryable();
        }

        public int Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
          
          
            db.Entry(entity).Property("CreatedBy").IsModified = false;
            db.Entry(entity).Property("CreatedDate").IsModified = false;

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            string[] current = (identity.Identity.Name).Split('&');

            var UpdatedBy = entity.GetType().GetProperty("UpdatedBy");
            var UpdatedDate = entity.GetType().GetProperty("UpdatedDate");
            UpdatedBy.SetValue(entity, current[0], null);
            UpdatedDate.SetValue(entity, DateTime.Now, null);



            return db.SaveChanges();
        }
    }
}