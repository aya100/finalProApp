using finalPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public class UserRepo<T> : IUser<T> where T : class
    {
        private finalProDBContext ctx;
        private DbSet<T> _set;
        public UserRepo()
        {
            ctx = new finalProDBContext();
            _set = ctx.Set<T>();
        }
        public T Add(T t)
        {
            _set.Add(t);
            return ctx.SaveChanges() > 0 ? t : null;
        }

        public bool Delete(T t)
        {
            _set.Remove(t);
            return ctx.SaveChanges() > 0;
        }

        public List<T> getAll()
        {
            return _set.ToList();
        }

        //public IQueryable<T> getAllFilter()
        //{
        //    return _set;
        //}

        public T getByID(params object[] id)
        {
           return _set.Find(id);
        }

        public bool Update(T t)
        {
            _set.Attach(t);
            ctx.Entry(t).State = EntityState.Modified;
            return ctx.SaveChanges() > 0;
        }
    }
}
