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
    public class OperationsAreas
    {
        private Repository<Area> areasRepo = new AreasRepository();
        public IEnumerable<AreaDto> GetAreas()
        {
            IEnumerable<Area> areas = areasRepo.List;
            List<AreaDto> areasDtos = new List<AreaDto>();
            foreach (var item in areas)
            {
                AreaDto areaDto = new AreaDto();
                areaDto.AreaId = item.AreaId;
                areaDto.CiudadId = item.CiudadId;
                areaDto.Nombre = item.Nombre;
                areaDto.Descripcion = item.Descripcion;
                areaDto.NombreCiudad = (item.Ciudad==null) ? string.Empty: item.Ciudad.Nombre;
                areasDtos.Add(areaDto);
            }
            return areasDtos;
        }

        public void AddAreas(AreaDto areaDto)
        {
            Area area = new Area();
            area.Nombre = areaDto.Nombre;
            area.Descripcion = areaDto.Descripcion;
            area.CiudadId = areaDto.CiudadId;
            areasRepo.Add(area);
        }

    }
}
