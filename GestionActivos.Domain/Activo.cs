using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.Domain
{
    public enum Estado
    {
        Activo,
        Reparacion,
        Eliminado,
        Disponible,
        Asignado
    }

    public class Activo
    {
        public int ActivoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long NumeroInternoInventario { get; set; }
        public float Peso { get; set; }
        public float Alto { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? FechaBaja { get; set; }
        public Estado? Estado{ get; set; }

        public int? AreaId { get; set; }

        public int? PersonaId { get; set; }

        public int? TipoActivoId { get; set; }

        public virtual Area Area { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual TipoActivo TipoActivo { get; set; }
    }
}
