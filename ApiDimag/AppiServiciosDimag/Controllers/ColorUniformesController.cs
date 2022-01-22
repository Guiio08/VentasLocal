using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AppiServiciosDimag.Models;

namespace AppiServiciosDimag.Controllers
{
    public class ColorUniformesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ColorUniformes
        public IQueryable<ColorUniforme> GetColorUniforme()
        {
            return db.ColorUniforme;
        }

        // GET: api/ColorUniformes/5
        [ResponseType(typeof(ColorUniforme))]
        public IHttpActionResult GetColorUniforme(int id)
        {
            ColorUniforme colorUniforme = db.ColorUniforme.Find(id);
            if (colorUniforme == null)
            {
                return NotFound();
            }

            return Ok(colorUniforme);
        }

        // PUT: api/ColorUniformes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColorUniforme(int id, ColorUniforme colorUniforme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorUniforme.id_color_uniforme)
            {
                return BadRequest();
            }

            db.Entry(colorUniforme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorUniformeExists(id))
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

        // POST: api/ColorUniformes
        [ResponseType(typeof(ColorUniforme))]
        public IHttpActionResult PostColorUniforme(ColorUniforme colorUniforme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ColorUniforme.Add(colorUniforme);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ColorUniformeExists(colorUniforme.id_color_uniforme))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = colorUniforme.id_color_uniforme }, colorUniforme);
        }

        // DELETE: api/ColorUniformes/5
        [ResponseType(typeof(ColorUniforme))]
        public IHttpActionResult DeleteColorUniforme(int id)
        {
            ColorUniforme colorUniforme = db.ColorUniforme.Find(id);
            if (colorUniforme == null)
            {
                return NotFound();
            }

            db.ColorUniforme.Remove(colorUniforme);
            db.SaveChanges();

            return Ok(colorUniforme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorUniformeExists(int id)
        {
            return db.ColorUniforme.Count(e => e.id_color_uniforme == id) > 0;
        }
    }
}