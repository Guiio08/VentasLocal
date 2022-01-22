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
    public class PedidoUniformesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PedidoUniformes
        public IQueryable<PedidoUniforme> GetPedidoUniforme()
        {
            return db.PedidoUniforme;
        }

        // GET: api/PedidoUniformes/5
        [ResponseType(typeof(PedidoUniforme))]
        public IHttpActionResult GetPedidoUniforme(int id)
        {
            PedidoUniforme pedidoUniforme = db.PedidoUniforme.Find(id);
            if (pedidoUniforme == null)
            {
                return NotFound();
            }

            return Ok(pedidoUniforme);
        }

        // PUT: api/PedidoUniformes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidoUniforme(int id, PedidoUniforme pedidoUniforme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoUniforme.id_pedido_uniforme)
            {
                return BadRequest();
            }

            db.Entry(pedidoUniforme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoUniformeExists(id))
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

        // POST: api/PedidoUniformes
        [ResponseType(typeof(PedidoUniforme))]
        public IHttpActionResult PostPedidoUniforme(PedidoUniforme pedidoUniforme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PedidoUniforme.Add(pedidoUniforme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidoUniforme.id_pedido_uniforme }, pedidoUniforme);
        }

        // DELETE: api/PedidoUniformes/5
        [ResponseType(typeof(PedidoUniforme))]
        public IHttpActionResult DeletePedidoUniforme(int id)
        {
            PedidoUniforme pedidoUniforme = db.PedidoUniforme.Find(id);
            if (pedidoUniforme == null)
            {
                return NotFound();
            }

            db.PedidoUniforme.Remove(pedidoUniforme);
            db.SaveChanges();

            return Ok(pedidoUniforme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoUniformeExists(int id)
        {
            return db.PedidoUniforme.Count(e => e.id_pedido_uniforme == id) > 0;
        }
    }
}
