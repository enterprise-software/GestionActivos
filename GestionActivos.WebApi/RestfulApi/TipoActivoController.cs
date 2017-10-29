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
    public class TipoActivoController : ApiController
    {
        private OperationsTiposActivos operationsData = new OperationsTiposActivos();
        // GET: api/TipoActivo
        public IEnumerable<TipoActivosDto> Get()
        {
            return operationsData.GetTipoActivos();
        }
        // POST: api/Persona
        [ResponseType(typeof(TipoActivosDto))]
        public IHttpActionResult Post(TipoActivosDto tiposActivo)
        {
            operationsData.AddTiposActivo(tiposActivo);
            return Ok(tiposActivo);
        }


    }
}
