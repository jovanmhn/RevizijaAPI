using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using RevizijaAPI.Models.Database;

namespace RevizijaAPI.Controllers
{

    public class knjigasController : ApiController
    {
        private Models.Database.Database db = new Models.Database.Database();

        // GET: api/knjigas
        public IHttpActionResult Getknjiga()
        {
            var result = db.knjiga.Select(qq => new Klase.JSONKnjiga()
            {
                id = qq.id_knjiga,
                godina = qq.godina,
                opis = qq.opis,
                klijent_naziv = qq.klijent.naziv
            });

            try
            {
                if (result == null) return BadRequest();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        [Route("api/knjigas/{id_klijent}")]
        public IHttpActionResult GetknjigaKlijent(int id_klijent)
        {
            var result = db.knjiga.Where(qq=> qq.id_klijent == id_klijent).Select(qq => new Klase.JSONKnjiga()
            {
                id = qq.id_knjiga,
                godina = qq.godina,
                opis = qq.opis ?? "",
                klijent_naziv = qq.klijent.naziv
            });

            try
            {
                if (result == null) return BadRequest();
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET: api/knjigas/5
        public IHttpActionResult Getknjiga(int id)
        {
            var knjiga = db.knjiga.FirstOrDefault(qq => qq.id_knjiga == id);
            if (knjiga == null)
            {
                return NotFound();
            }
            Klase.JSONKnjiga knjiga_json = new Klase.JSONKnjiga()
            {
                id = knjiga.id_knjiga,
                godina = knjiga.godina,
                opis = knjiga.opis,
                klijent_naziv = knjiga.klijent.naziv
            };
            return Ok(knjiga_json);
        }

        //Moj custom put
        [Route("api/knjigas/upload/{id_knjiga}/{naziv}/{id_operater}")]
        [HttpPut]
        public async Task<IHttpActionResult> Upload2DMS(int id_knjiga, string naziv, int? id_operater)
        {
            try
            {
                var dms_ostalo = await db.dms_file.FirstOrDefaultAsync(qq => qq.id_knjiga == id_knjiga && qq.naziv == "OSTALO" && qq.is_editable == true);
                if (dms_ostalo != null)
                {
                    byte[] img_array = await Request.Content.ReadAsByteArrayAsync();
                    Image x = (Bitmap)((new ImageConverter()).ConvertFrom(img_array));

                    if (Klase.ImageToPdf.ConvertImageToPdf(x, naziv, dms_ostalo, id_operater.Value)) return Ok();
                    else return (InternalServerError());
                }
                else return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        // PUT: api/knjigas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putknjiga(int id, knjiga knjiga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != knjiga.id_knjiga)
            {
                return BadRequest();
            }

            db.Entry(knjiga).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!knjigaExists(id))
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

        // POST: api/knjigas
        [ResponseType(typeof(knjiga))]
        public async Task<IHttpActionResult> Postknjiga(knjiga knjiga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.knjiga.Add(knjiga);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = knjiga.id_knjiga }, knjiga);
        }

        // DELETE: api/knjigas/5
        [ResponseType(typeof(knjiga))]
        public async Task<IHttpActionResult> Deleteknjiga(int id)
        {
            knjiga knjiga = await db.knjiga.FindAsync(id);
            if (knjiga == null)
            {
                return NotFound();
            }

            db.knjiga.Remove(knjiga);
            await db.SaveChangesAsync();

            return Ok(knjiga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool knjigaExists(int id)
        {
            return db.knjiga.Count(e => e.id_knjiga == id) > 0;
        }
    }

}
