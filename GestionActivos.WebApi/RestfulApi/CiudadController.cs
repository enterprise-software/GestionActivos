using GestionActivos.BusinessLogic;
using GestionActivos.Dtos;
using GestionActivos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GestionActivos.WebApi.RestfulApi
{
    public class CiudadController : ApiController
    {
        private OperationsCiudades operationsData = new OperationsCiudades();
        // GET: api/Ciudad
        public IEnumerable<CiudadDto> Get()
        {
            return operationsData.GetCiudades();
        }

        // GET: api/Ciudad/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ciudad
        [ResponseType(typeof(CiudadDto))]
        public IHttpActionResult Post(CiudadDto ciudad)
        {
            operationsData.AddCiudad(ciudad);
            return Ok(ciudad);
        }

        // PUT: api/Ciudad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ciudad/5
        public void Delete(int id)
        {
        }
    }
}
