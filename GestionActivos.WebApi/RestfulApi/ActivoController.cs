using GestionActivos.BusinessLogic;
using GestionActivos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GestionActivos.WebApi.RestfulApi
{
    public class ActivoController : ApiController
    {
        private OperationsActivos operationsData = new OperationsActivos();

        // GET: api/Activo
        public IEnumerable<ActivosDto> Get()
        {
            return operationsData.GetActivos();
        }

        // GET: api/Activo/5
        [ResponseType(typeof(ActivosDto))]
        public IHttpActionResult Get(int id)
        {
            return Ok(operationsData.GetActivosById(id));
        }

        // POST: api/Activo
        [ResponseType(typeof(ActivosDto))]
        public IHttpActionResult Post(ActivosDto activos)
        {
            operationsData.AddActivos(activos);
            return Ok(activos);
        }

        // PUT: api/Activo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, ActivosDto activos)
        {
            operationsData.UpdateActivos(id, activos);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Activo/5
        public void Delete(int id)
        {
        }
    }
}
