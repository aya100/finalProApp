using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public class AdminRepo : IAdmin
    {
        private finalProDBContext ctx;
        public AdminRepo()
        {
            ctx = new finalProDBContext();
        }
        public Admin Add(Admin t)
        {
            ctx.Admin.Add(t);
            return ctx.SaveChanges() > 0 ? t : null;
        }

        public Admin getByName(string name)
        {
            return ctx.Admin.Find(name);
        }
    }
}
