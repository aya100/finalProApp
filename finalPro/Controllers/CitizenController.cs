using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using finalPro.Models;
using finalPro.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace finalPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        ICitizen db;
        public CitizenController(ICitizen _db)
        {
            db = _db;
        }
        [HttpGet]
        public ActionResult getall()
        {
            return Ok(db.GetCitizens());
        }
        [HttpGet("{nationalID}")]
        public ActionResult<Citizen> studentbyId(string nid)
        {
            Citizen c = db.GetByNID(nid);
            if (c == null)
                return NotFound();
            else
                return c;
        }
        [HttpPost]
        public IActionResult addCitizen([FromForm] Citizen c, [FromForm] IFormFile Photo)
        {
            if (Photo != null)

            {
                if (Photo.Length > 0)

                {
                    using (var ms = new MemoryStream())
                    {
                        Photo.CopyTo(ms);
                        c.Photo = ms.ToArray();
                    }
                }
            }

            db.AddCitizen(c);
            return Created("Citizen Table", c);
            ////////////////////////////////////////
        }
    }
}
