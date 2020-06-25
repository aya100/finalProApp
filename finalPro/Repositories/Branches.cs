using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public class Branches : IBranches
    {
        private finalProDBContext ctx;
        public Branches(finalProDBContext _ctx)
        {
            this.ctx = _ctx;
        }
        public List<string> branchesName()
        {
            return ctx.OrgBranches.Select(b => b.Name).ToList();
        }

        public List<string> branchNameFilter(int orgId)
        {
            return ctx.OrgBranches.Where(b => b.OrgId == orgId).Select(b => b.Name).ToList();
        }
        public int getBranchId(string name)
        {
            return ctx.OrgBranches.Where(b => b.Name == name).Select(b => b.Id).First();
        }

        
    }
}
