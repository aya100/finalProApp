using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public interface ICitizen
    {

        IEnumerable<Citizen> GetCitizens();
        void AddCitizen(Citizen dt);
        Citizen GetByNID(string nid);
    }
}
