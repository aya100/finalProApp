using System;
using System.Collections.Generic;

namespace finalPro.Models
{
    public partial class Logs
    {
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual User User { get; set; }
    }
}
