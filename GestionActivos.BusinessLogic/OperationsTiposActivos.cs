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
    public class OperationsTiposActivos
    {
        private Repository<TipoActivo> tipoActivoRepo = new TipoActivoRepository();
        public IEnumerable<TipoActivosDto> GetTipoActivos()
        {
            IList<TipoActivosDto> tiposActivosDtos = new List<TipoActivosDto>();
            IEnumerable<TipoActivo> tiposActivo = tipoActivoRepo.List;
            foreach (var item in tiposActivo)
            {
                TipoActivosDto tipoActDto = new TipoActivosDto();
                tipoActDto.Descripcion = item.Descripcion;
                tipoActDto.Nombre = item.Nombre;
                tipoActDto.TipoActivoId = item.TipoActivoId;
                tiposActivosDtos.Add(tipoActDto);
            }
            return tiposActivosDtos;
        }

        public void AddTiposActivo(TipoActivosDto tiposActivoDto)
        {
            TipoActivo tipoActivo = new TipoActivo();
            tipoActivo.Nombre = tiposActivoDto.Nombre;
            tipoActivo.Descripcion = tiposActivoDto.Descripcion;
            tipoActivoRepo.Add(tipoActivo);
        }
    }
}
