using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class OrgBranches
    {
        public OrgBranches()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? OrgId { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Long { get; set; }

        public virtual Organization Org { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
