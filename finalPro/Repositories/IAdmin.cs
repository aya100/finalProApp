using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public interface IAdmin
    {
        Admin getByName(string name);
        Admin Add(Admin t);
    }
}
