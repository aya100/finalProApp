using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class Organization
    {
        public Organization()
        {
            OrgBranches = new HashSet<OrgBranches>();
            Requist = new HashSet<Requist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrgBranches> OrgBranches { get; set; }
        public virtual ICollection<Requist> Requist { get; set; }
    }
}
