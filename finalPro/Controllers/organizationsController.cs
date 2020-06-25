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
    public class organizationsController : ControllerBase
    {
        private OrganisationRepo org;
        public organizationsController(OrganisationRepo _org)
        {
            this.org = _org;
        }

        [HttpGet]
        [Route("orgNames")]
        public List<string> getorgNames()
        {
            return this.org.orgNames();
        }
    }
}
