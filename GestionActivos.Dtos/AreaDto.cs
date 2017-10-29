using System.ComponentModel;

namespace GestionActivos.Dtos
{
    public class AreaDto
    {
        public int AreaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CiudadId { get; set; }
        [DisplayName("Ciudad")]
        public string NombreCiudad { get; set; }
    }
}
