using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDemo.Controllers
{
    [Authorize]
    public class StuffController : ApiController
    {
        Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        public StuffController()
        {

        }
        public IHttpActionResult GetStuff(int Id)
        {
          var stuff=  db.Stuffs.FirstOrDefault(p => p.Id == Id);
            if (stuff == null)
                return NotFound();
            return Ok(stuff);
        }
        public IHttpActionResult GetStuffs()
        {
            return Ok(db.Stuffs);
        }
        public IHttpActionResult AddStuff(Models.Stuff stuff)
        {
            db.Stuffs.Add(stuff);
            db.SaveChanges();
            return Ok();
        }
    }
}
