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
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ProductsController : ApiController
    {
        private WebApplication4Context db = new WebApplication4Context();

        // GET: api/Products
        public IQueryable<Produtos> GetProdutos()
        {
            return db.Produtos;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult GetProdutos(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return NotFound();
            }

            return Ok(produtos);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdutos(int id, Produtos produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtos.Id)
            {
                return BadRequest();
            }

            db.Entry(produtos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult PostProdutos(Produtos produtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtos.Add(produtos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produtos.Id }, produtos);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Produtos))]
        public IHttpActionResult DeleteProdutos(int id)
        {
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(produtos);
            db.SaveChanges();

            return Ok(produtos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutosExists(int id)
        {
            return db.Produtos.Count(e => e.Id == id) > 0;
        }
    }
}