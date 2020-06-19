using finalPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalPro.Repositories
{
    public class organisationRepo : IorganisationRepo
    {
        private finalProDBContext db;
        public organisationRepo(finalProDBContext db)
        {
            this.db = db;
        }

        public List<Organization> getall()
        {
            return db.Organization.ToList();
        }
        public Organization getbyid(int id)
        {
            return db.Organization.Find(id);
        }
        public Organization getbyname(string name)
        {
            return db.Organization.Find(name);
        }

        //public Organization getbytype(string name)
        //{
        //    var filtered = db.Organization;
        //    foreach (var o in filtered)
        //    {
        //        filtered = filtered.Where(p => p.Name.Contains());
        //    }
        //    return filtered;
        //}
        public void add(Organization o)
        {
            db.Organization.Add(o);
            db.SaveChanges();
        }
        public bool PUT(Organization o)
        {
            //var updatedOrganisation = db.Organization.Find(id);
            //updatedOrganisation.Id = o.Id;
            //updatedOrganisation.Name = o.Name;
            //updatedOrganisation.Type = o.Type;
            //updatedOrganisation.Long = o.Long;
            //updatedOrganisation.Lat = o.Lat;

            //db.SaveChanges();

            db.Organization.Attach(o);
            db.Entry(o).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public void delete(int id)
        {
            Organization o = db.Organization.Find(id);

            db.Organization.Remove(o);
            db.SaveChanges();
        }
    }


}
