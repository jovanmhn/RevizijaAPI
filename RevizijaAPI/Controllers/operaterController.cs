using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace RevizijaAPI.Controllers
{
    [RoutePrefix("api/operater")]
    public class operaterController : ApiController
    {
        private Models.Database.Database db = new Models.Database.Database();
        // GET: api/operater
        public IHttpActionResult Get( bool samo_admin = false)
        {
            try
            {
                if (samo_admin)
                {
                    return Ok(db.operater.Where(qq=> qq.username == "root").Select(qq => new Klase.JSONOperater
                    {
                        id_operater = qq.id_operater,
                        ime = qq.ime,
                        prezime = qq.prezime,
                        username = qq.username
                    }));
                }
                else
                {

                    return Ok(db.operater.Select(qq => new Klase.JSONOperater
                    {
                        id_operater = qq.id_operater,
                        ime = qq.ime,
                        prezime = qq.prezime,
                        username = qq.username
                    }).ToList());
                }
            }
            catch (Exception)
            {
                //loguj?
                return InternalServerError();
            }
        }

        [Route("login/{username}/{password}")] //putanja
        [HttpGet] //koje tipove zahtjeva dozvoljava
        public IHttpActionResult Login(string username, string password)
        {
            
            if(db.operater.Any(qq=> qq.username == username && qq.password == password))
            {
                try
                {
                    var result = db.operater.Where(qq => qq.username == username && qq.password == password)
                                 .Select(ww => new Klase.JSONOperater { id_operater = ww.id_operater, ime = ww.ime, prezime = ww.prezime, username = ww.username }
                                 ).FirstOrDefault();
                    if (result == null) return NotFound();
                    return Ok(result);
                }
                catch (Exception)
                {
                    return InternalServerError();
                }

            }
            else
            {
                return BadRequest("Netacni login podaci!");
            }
        }

        // GET: api/operater/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/operater
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/operater/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/operater/5
        public void Delete(int id)
        {
        }
    }
}
