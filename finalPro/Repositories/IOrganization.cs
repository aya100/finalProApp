using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public interface IorganisationRepo
    {
        //List<Organization> getAllorg();
        List<string> orgNames();
        //List<string> getOrgname(int id);

    }

}
