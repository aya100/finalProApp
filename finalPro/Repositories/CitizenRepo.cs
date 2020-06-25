using finalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public class CitizenRepo:ICitizen
    {
        finalProDBContext db;
        public CitizenRepo(finalProDBContext _db)
        {
            db = _db;
        }
        public IEnumerable<Citizen> GetCitizens()
        {
            return db.Citizen;
        }
        public void AddCitizen(Citizen ct)
        {
            db.Citizen.Add(ct);
        }
        public Citizen GetByNID(string nid)
        {
            Citizen c = db.Citizen.FirstOrDefault(a => a.NationalId == nid);
            return c;
        }

        
    }
}
