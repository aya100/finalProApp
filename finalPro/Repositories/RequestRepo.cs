using finalPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public class RequestRepo : IRequest
    {
        private finalProDBContext ctx;

        public RequestRepo()
        {
            ctx = new finalProDBContext();
        }
        public Requist Add(Requist R)
        {
           ctx.Requist.Add(R);
           return ctx.SaveChanges()>0? R : null;
        }

        public bool Delete(Requist R)
        {
            ctx.Requist.Remove(R);
            return ctx.SaveChanges() > 0;
        }

        public List<Requist> getAll()
        {
            return ctx.Requist.ToList();
        }

        public Requist getByID(params object[] id)
        {
            return ctx.Requist.Find(id);
        }

        public bool Update(Requist R)
        {
            ctx.Requist.Attach(R);
            ctx.Entry(R).State = EntityState.Modified;
            return ctx.SaveChanges() > 0;
        }
    }
}
