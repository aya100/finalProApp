using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalPro.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace finalPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private Branches b;
        public BranchesController(Branches _b)
        {
            this.b = _b;
        }
        [HttpGet]
        [Route("branches")]
        public List<string> getBranchesName()
        {
            return b.branchesName();
        }
        [HttpGet]
        [Route("branches/{orgId}")]
        public List<string> getBranchesNameFilter(int orgId)
        {
            return b.branchNameFilter(orgId);
        }

        [HttpGet]
        [Route("branche/{name}")]
        public int getBranchId(string name)
        {
            return b.getBranchId(name);
        }
    }
}
