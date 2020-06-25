using finalPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public class OrganisationRepo : IorganisationRepo
    {

        private finalProDBContext fp;
        public OrganisationRepo(finalProDBContext _fb)
        {
            this.fp = _fb;
        }
        //public List<Organization> getAllorg()
        //{
        //    return fp.Organization.ToList();
        //}


        public List<string> orgNames()
        {
            return fp.Organization.Select(a => a.Name).ToList();
        }

        //public List<string> getOrgname(int id)
        //{
        //    var na = from a in fp.Organization
        //             join b in fp.OrgBranches
        //             on a.Id equals b.OrgId
        //             where a.Id == id
        //             select b.Name;

        //    return na.ToList();
        //}

    }
}
