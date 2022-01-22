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
    public class OrdenComprasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/OrdenCompras
        public IQueryable<OrdenCompra> GetOrdenCompra()
        {
            return db.OrdenCompra;
        }

        // GET: api/OrdenCompras/5
        [ResponseType(typeof(OrdenCompra))]
        public IHttpActionResult GetOrdenCompra(int id)
        {
            OrdenCompra ordenCompra = db.OrdenCompra.Find(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return Ok(ordenCompra);
        }

        // PUT: api/OrdenCompras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrdenCompra(int id, OrdenCompra ordenCompra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordenCompra.id_orden_compra)
            {
                return BadRequest();
            }

            db.Entry(ordenCompra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenCompraExists(id))
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

        // POST: api/OrdenCompras
        [ResponseType(typeof(OrdenCompra))]
        public IHttpActionResult PostOrdenCompra(OrdenCompra ordenCompra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrdenCompra.Add(ordenCompra);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ordenCompra.id_orden_compra }, ordenCompra);
        }

        // DELETE: api/OrdenCompras/5
        [ResponseType(typeof(OrdenCompra))]
        public IHttpActionResult DeleteOrdenCompra(int id)
        {
            OrdenCompra ordenCompra = db.OrdenCompra.Find(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            db.OrdenCompra.Remove(ordenCompra);
            db.SaveChanges();

            return Ok(ordenCompra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdenCompraExists(int id)
        {
            return db.OrdenCompra.Count(e => e.id_orden_compra == id) > 0;
        }
    }
}