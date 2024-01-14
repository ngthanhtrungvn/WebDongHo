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
using DuAnWebsite.Models;
using System.Web.Mvc;

namespace DuAnWebsite.Areas.Admin.Controllers.API
{
    public class ACCOUNTsController : ApiController
    {
        private QL_SHOPDONGHOOEntities db = new QL_SHOPDONGHOOEntities();

        // GET: api/ACCOUNTs
        public IQueryable<ACCOUNT> GetACCOUNTs()
        {
            return db.ACCOUNTs;
        }

        // GET: api/ACCOUNTs/5
        [ResponseType(typeof(ACCOUNT))]
        public IHttpActionResult GetACCOUNT(string id)
        {
            ACCOUNT aCCOUNT = db.ACCOUNTs.Find(id);
            if (aCCOUNT == null)
            {
                return NotFound();
            }

            return Ok(aCCOUNT);
        }

        // PUT: api/ACCOUNTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutACCOUNT(string id, ACCOUNT aCCOUNT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aCCOUNT.USERNAME)
            {
                return BadRequest();
            }

            db.Entry(aCCOUNT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ACCOUNTExists(id))
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

        // POST: api/ACCOUNTs
        [ResponseType(typeof(ACCOUNT))]
        public IHttpActionResult PostACCOUNT(ACCOUNT aCCOUNT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ACCOUNTs.Add(aCCOUNT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ACCOUNTExists(aCCOUNT.USERNAME))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aCCOUNT.USERNAME }, aCCOUNT);
        }

        // DELETE: api/ACCOUNTs/5
        [ResponseType(typeof(ACCOUNT))]
        public IHttpActionResult DeleteACCOUNT(string id)
        {
            ACCOUNT aCCOUNT = db.ACCOUNTs.Find(id);
            if (aCCOUNT == null)
            {
                return NotFound();
            }

            db.ACCOUNTs.Remove(aCCOUNT);
            db.SaveChanges();

            return Ok(aCCOUNT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ACCOUNTExists(string id)
        {
            return db.ACCOUNTs.Count(e => e.USERNAME == id) > 0;
        }

        
    }
}