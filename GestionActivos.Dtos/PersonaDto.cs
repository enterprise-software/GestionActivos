using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.Dtos
{
    public class PersonaDto
    {
        public int PersonaId { get; set; }
        [DisplayName("Identificacion")]
        public string DocumentoIdentidad { get; set; }
        public string Nombre { get; set; }
    }
}
