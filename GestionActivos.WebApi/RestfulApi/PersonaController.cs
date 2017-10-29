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
    public class PersonaController : ApiController
    {
        private OperationsPersonas operationsData = new OperationsPersonas();
        // GET: api/Persona
        public IEnumerable<PersonaDto> Get()
        {
            return operationsData.GetPersonas();
        }
        // GET: api/Area


        // GET: api/Persona/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Persona
        [ResponseType(typeof(PersonaDto))]
        public IHttpActionResult Post(PersonaDto persona)
        {
            operationsData.AddPersonas(persona);
            return Ok(persona);
        }

        // PUT: api/Persona/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Persona/5
        public void Delete(int id)
        {
        }
    }
}
