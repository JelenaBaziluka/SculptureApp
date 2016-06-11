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
using WebServiceDemo;

namespace WebServiceDemo.Controllers
{
    public class DamagesController : ApiController
    {
        private SculptureContext db = new SculptureContext();

        // GET: api/Damages
        public IQueryable<Damage> GetDamages()
        {
            return db.Damages;
        }

        // GET: api/Damages/5
        [ResponseType(typeof(Damage))]
        public IHttpActionResult GetDamage(int id)
        {
            Damage damage = db.Damages.Find(id);
            if (damage == null)
            {
                return NotFound();
            }

            return Ok(damage);
        }

        // PUT: api/Damages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDamage(int id, Damage damage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != damage.Damage_Id)
            {
                return BadRequest();
            }

            db.Entry(damage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DamageExists(id))
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

        // POST: api/Damages
        [ResponseType(typeof(Damage))]
        public IHttpActionResult PostDamage(Damage damage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Damages.Add(damage);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DamageExists(damage.Damage_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = damage.Damage_Id }, damage);
        }

        // DELETE: api/Damages/5
        [ResponseType(typeof(Damage))]
        public IHttpActionResult DeleteDamage(int id)
        {
            Damage damage = db.Damages.Find(id);
            if (damage == null)
            {
                return NotFound();
            }

            db.Damages.Remove(damage);
            db.SaveChanges();

            return Ok(damage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DamageExists(int id)
        {
            return db.Damages.Count(e => e.Damage_Id == id) > 0;
        }
    }
}