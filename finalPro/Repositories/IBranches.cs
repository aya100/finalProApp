using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public interface IBranches
    {
        List<string> branchesName();
        List<string> branchNameFilter(int orgId);
        int getBranchId(string name);
    }
}
