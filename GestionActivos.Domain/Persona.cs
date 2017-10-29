using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.Domain
{
    public class Persona
    {
        public int PersonaId { get; set; }

        public string DocumentoIdentidad { get; set; }

        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activo> Activo { get; set; }
    }
}
