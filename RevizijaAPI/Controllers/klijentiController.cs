using RevizijaAPI.Models.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace RevizijaAPI.Controllers
{
    public class klijentsController : ApiController
    {
        private Models.Database.Database db = new Models.Database.Database();

        // GET: api/klijents
        public IHttpActionResult Getklijent()
        {
            try
            {
                var result = db.klijent.Select(qq => new Klase.JSONKlijent { id_klijent = qq.id_klijent, direktor_ime = qq.direktor_ime, naziv = qq.naziv, pdv = qq.pdv, PIB = qq.PIB }).ToList();
                
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [Route("api/klijents/direktori")] //putanja
        [HttpGet, HttpPost] //koje tipove zahtjeva dozvoljava
        public List<string> GetDirektori()
        {
            return db.klijent.Select(qq => qq.direktor_ime).ToList();
        }

        // GET: api/klijents/5
        [ResponseType(typeof(klijent))]
        public async Task<IHttpActionResult> Getklijent(int id)
        {
            klijent klijent = await db.klijent.FindAsync(id);
            if (klijent == null)
            {
                return NotFound();
            }

            return Ok(klijent);
        }

        // PUT: api/klijents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putklijent(int id, klijent klijent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != klijent.id_klijent)
            {
                return BadRequest();
            }

            db.Entry(klijent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!klijentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/klijents
        [ResponseType(typeof(klijent))]
        public async Task<IHttpActionResult> Postklijent(klijent klijent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.klijent.Add(klijent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = klijent.id_klijent }, klijent);
        }

        // DELETE: api/klijents/5
        [ResponseType(typeof(klijent))]
        public async Task<IHttpActionResult> Deleteklijent(int id)
        {
            klijent klijent = await db.klijent.FindAsync(id);
            if (klijent == null)
            {
                return NotFound();
            }

            db.klijent.Remove(klijent);
            await db.SaveChangesAsync();

            return Ok(klijent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool klijentExists(int id)
        {
            return db.klijent.Count(e => e.id_klijent == id) > 0;
        }



    }
}
