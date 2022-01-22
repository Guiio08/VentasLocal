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
    public class ColorEmbonesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ColorEmbones
        public IQueryable<ColorEmbone> GetColorEmbone()
        {
            return db.ColorEmbone;
        }

        // GET: api/ColorEmbones/5
        [ResponseType(typeof(ColorEmbone))]
        public IHttpActionResult GetColorEmbone(int id)
        {
            ColorEmbone colorEmbone = db.ColorEmbone.Find(id);
            if (colorEmbone == null)
            {
                return NotFound();
            }

            return Ok(colorEmbone);
        }

        // PUT: api/ColorEmbones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColorEmbone(int id, ColorEmbone colorEmbone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorEmbone.id_color_embone)
            {
                return BadRequest();
            }

            db.Entry(colorEmbone).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorEmboneExists(id))
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

        // POST: api/ColorEmbones
        [ResponseType(typeof(ColorEmbone))]
        public IHttpActionResult PostColorEmbone(ColorEmbone colorEmbone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ColorEmbone.Add(colorEmbone);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ColorEmboneExists(colorEmbone.id_color_embone))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = colorEmbone.id_color_embone }, colorEmbone);
        }

        // DELETE: api/ColorEmbones/5
        [ResponseType(typeof(ColorEmbone))]
        public IHttpActionResult DeleteColorEmbone(int id)
        {
            ColorEmbone colorEmbone = db.ColorEmbone.Find(id);
            if (colorEmbone == null)
            {
                return NotFound();
            }

            db.ColorEmbone.Remove(colorEmbone);
            db.SaveChanges();

            return Ok(colorEmbone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorEmboneExists(int id)
        {
            return db.ColorEmbone.Count(e => e.id_color_embone == id) > 0;
        }
    }
}