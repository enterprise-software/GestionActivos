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
    public class AreaController : ApiController
    {
        private OperationsAreas operationsData = new OperationsAreas();
        // GET: api/Area
        public IEnumerable<AreaDto> Get()
        {
            return operationsData.GetAreas();
        }

        // GET: api/Area/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Area
        [ResponseType(typeof(AreaDto))]
        public IHttpActionResult Post(AreaDto area)
        {
            operationsData.AddAreas(area);

            return Ok(area);
        }

        // PUT: api/Area/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Area/5
        public void Delete(int id)
        {
        }
    }
}
