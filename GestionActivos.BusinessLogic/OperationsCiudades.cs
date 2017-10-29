using GestionActivos.Domain;
using GestionActivos.Dtos;
using GestionActivos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.BusinessLogic
{
    public class OperationsCiudades
    {
        private Repository<Ciudad> ciudadRepo = new CiudadRepository();
        public IEnumerable<CiudadDto> GetCiudades()
        {
            IEnumerable<Ciudad> ciudades = ciudadRepo.List;
            List<CiudadDto> ciudadesDtos = new List<CiudadDto>();
            foreach (var item in ciudades)
            {
                CiudadDto ciudadDto = new CiudadDto();
                ciudadDto.CiudadId = item.CiudadId;
                ciudadDto.Descripcion = item.Descripcion;
                ciudadDto.Nombre = item.Nombre;
                ciudadesDtos.Add(ciudadDto);
            }
            return ciudadesDtos;
        }   

        public void AddCiudad(CiudadDto ciudadDto)
        {
            Ciudad ciudad = new Ciudad();
            ciudad.Nombre = ciudadDto.Nombre;
            ciudad.Descripcion = ciudadDto.Descripcion;
            ciudadRepo.Add(ciudad);
        }
    }
}
