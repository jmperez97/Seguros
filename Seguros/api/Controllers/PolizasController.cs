using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using api.Models;

namespace api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using api.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Poliza>("Polizas");
    builder.EntitySet<ClientesXpoliza>("ClientesXpolizas"); 
    builder.EntitySet<PolizasXTipos>("PolizasXTipos"); 
    builder.EntitySet<Riesgo>("Riesgoes"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PolizasController : ODataController
    {
        private ModelSeguros db = new ModelSeguros();

        // GET: odata/Polizas
        [EnableQuery]
        public IQueryable<Poliza> GetPolizas()
        {
            return db.Polizas;
        }

        // GET: odata/Polizas(5)
        [EnableQuery]
        public SingleResult<Poliza> GetPoliza([FromODataUri] int key)
        {
            return SingleResult.Create(db.Polizas.Where(poliza => poliza.idPoliza == key));
        }

        // PUT: odata/Polizas(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Poliza> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Poliza poliza = await db.Polizas.FindAsync(key);
            if (poliza == null)
            {
                return NotFound();
            }

            patch.Put(poliza);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolizaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(poliza);
        }

        // POST: odata/Polizas
        public async Task<IHttpActionResult> Post(Poliza poliza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Polizas.Add(poliza);
            await db.SaveChangesAsync();

            return Created(poliza);
        }

        // PATCH: odata/Polizas(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Poliza> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Poliza poliza = await db.Polizas.FindAsync(key);
            if (poliza == null)
            {
                return NotFound();
            }

            patch.Patch(poliza);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolizaExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(poliza);
        }

        // DELETE: odata/Polizas(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Poliza poliza = await db.Polizas.FindAsync(key);
            if (poliza == null)
            {
                return NotFound();
            }

            db.Polizas.Remove(poliza);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Polizas(5)/ClientesXpolizas
        [EnableQuery]
        public IQueryable<ClientesXpoliza> GetClientesXpolizas([FromODataUri] int key)
        {
            return db.Polizas.Where(m => m.idPoliza == key).SelectMany(m => m.ClientesXpolizas);
        }

        // GET: odata/Polizas(5)/PolizasXTipos
        [EnableQuery]
        public IQueryable<PolizasXTipos> GetPolizasXTipos([FromODataUri] int key)
        {
            return db.Polizas.Where(m => m.idPoliza == key).SelectMany(m => m.PolizasXTipos);
        }

        // GET: odata/Polizas(5)/Riesgo
        [EnableQuery]
        public SingleResult<Riesgo> GetRiesgo([FromODataUri] int key)
        {
            return SingleResult.Create(db.Polizas.Where(m => m.idPoliza == key).Select(m => m.Riesgo));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolizaExists(int key)
        {
            return db.Polizas.Count(e => e.idPoliza == key) > 0;
        }
    }
}
