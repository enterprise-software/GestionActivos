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
    public class OperationsActivos
    {
        private Repository<Activo> activosRepo = new ActivoRepository();
        public IEnumerable<ActivosDto> GetActivos()
        {
            IEnumerable<Activo> activos = activosRepo.List;
            List<ActivosDto> activosDtos = new List<ActivosDto>();
            foreach (var item in activos)
            {
                if (item.Estado == Domain.Estado.Activo)
                {
                    ActivosDto activoDto = new ActivosDto();
                    activoDto.ActivoId = item.ActivoId;
                    activoDto.Alto = item.Alto;
                    activoDto.AreaId = item.AreaId;
                    activoDto.Descripcion = item.Descripcion;
                    activoDto.FechaBaja = item.FechaBaja;
                    activoDto.FechaCompra = item.FechaCompra;
                    activoDto.Nombre = item.Nombre;
                    activoDto.NombreArea = (item.Area == null) ? string.Empty : item.Area.Nombre;
                    activoDto.NombrePersona = (item.Persona == null) ? string.Empty : item.Persona.Nombre;
                    activoDto.NombreTipoActivo = (item.TipoActivo == null) ? string.Empty : item.TipoActivo.Nombre;
                    activoDto.NumeroInternoInventario = item.NumeroInternoInventario;
                    activoDto.ValorCompra = item.ValorCompra;
                    activoDto.PersonaId = item.PersonaId;
                    activoDto.TipoActivoId = item.TipoActivoId;
                    activoDto.AreaId = item.AreaId;
                    activoDto.Estado = (Dtos.Estado)item.Estado;
                    activosDtos.Add(activoDto);
                }
            }
            return activosDtos;
        }

        public ActivosDto GetActivosById(int Id)
        {
            Activo activos = activosRepo.FindById(Id);
            ActivosDto activoDto = new ActivosDto();
            activoDto.ActivoId = activos.ActivoId;
            activoDto.Alto = activos.Alto;
            activoDto.AreaId = activos.AreaId;
            activoDto.Descripcion = activos.Descripcion;
            activoDto.FechaBaja = activos.FechaBaja;
            activoDto.FechaCompra = activos.FechaCompra;
            activoDto.Nombre = activos.Nombre;
            activoDto.NombreArea = (activos.Area == null) ? string.Empty : activos.Area.Nombre;
            activoDto.NombrePersona = (activos.Persona == null) ? string.Empty : activos.Persona.Nombre;
            activoDto.NombreTipoActivo = (activos.TipoActivo == null) ? string.Empty : activos.TipoActivo.Nombre;
            activoDto.NumeroInternoInventario = activos.NumeroInternoInventario;
            activoDto.ValorCompra = activos.ValorCompra;
            activoDto.PersonaId = activos.PersonaId;
            activoDto.TipoActivoId = activos.TipoActivoId;
            activoDto.AreaId = activos.AreaId;
            activoDto.Estado = (Dtos.Estado)activos.Estado;
            return activoDto;
        }

        public void AddActivos(ActivosDto activoDto)
        {
            Activo activo = new Activo();
            activo.Peso = activoDto.Peso;
            activo.Alto = activoDto.Alto;
            activo.AreaId = activoDto.AreaId;
            activo.Descripcion = activoDto.Descripcion;
            activo.FechaCompra = DateTime.Now.Date;
            activo.Nombre = activoDto.Nombre;
            activo.NumeroInternoInventario = activoDto.NumeroInternoInventario;
            activo.ValorCompra = activoDto.ValorCompra;
            activo.PersonaId = activoDto.PersonaId;
            activo.TipoActivoId = activoDto.TipoActivoId;
            activo.AreaId = activoDto.AreaId;
            activo.Estado = (GestionActivos.Domain.Estado)activoDto.Estado;
            activosRepo.Add(activo);
        }

        public void UpdateActivos(int id, ActivosDto activoDto)
        {
            Activo activo = new Activo();
            activo.FechaBaja = activoDto.FechaBaja;
            activo.NumeroInternoInventario = activoDto.NumeroInternoInventario;
            activosRepo.Update(id,activo);
        }
    }
}
