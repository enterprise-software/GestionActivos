using GestionActivos.Domain;
using GestionActivos.Repository;
using GestionActivos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.BusinessLogic
{
    public class OperationsPersonas
    {
        private Repository<Persona> personaRepo = new PersonasRepository();
        public IEnumerable<PersonaDto> GetPersonas()
        {
            IEnumerable<Persona> personas = personaRepo.List;
            List<PersonaDto> personasDtos = new List<PersonaDto>();
            foreach (var item in personas)
            {
                PersonaDto personaDto = new PersonaDto();
                personaDto.Nombre = item.Nombre;
                personaDto.PersonaId = item.PersonaId;
                personaDto.DocumentoIdentidad = item.DocumentoIdentidad;

                personasDtos.Add(personaDto);
            }
            return personasDtos;
        }

        public void AddPersonas(PersonaDto personaDto)
        {
            Persona persona = new Persona();
            persona.Nombre = personaDto.Nombre;
            persona.DocumentoIdentidad = personaDto.DocumentoIdentidad;

            personaRepo.Add(persona);
        }
    }
}
