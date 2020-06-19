using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public interface IorganisationRepo
    {
        List<Organization> getall();

        Organization getbyid(int id);
        Organization getbyname(string name);

        void add(Organization o);
        bool PUT(Organization o);
        void delete(int id);
    }

}
