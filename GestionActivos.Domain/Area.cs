using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.Domain
{
    public class Area
    {
        public int AreaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int? CiudadId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activo> Activo { get; set; }

        public virtual Ciudad Ciudad { get; set; }
    }
}
