using System;
using System.ComponentModel;
namespace GestionActivos.Dtos
{
    public enum Estado
    {
        Activo,
        Reparacion,
        Eliminado,
        Disponible,
        Asignado
    }

    public class ActivosDto
    {
        public int ActivoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [DisplayName("Nro Inventario")]
        public long NumeroInternoInventario { get; set; }
        public float Peso { get; set; }
        public float Alto { get; set; }
        [DisplayName("Vlr de compra")]
        public decimal ValorCompra { get; set; }
        [DisplayName("Fecha de compra")]
        public DateTime? FechaCompra { get; set; }
        [DisplayName("Fecha de baja")]
        public DateTime? FechaBaja { get; set; }
        public Estado? Estado { get; set; }
        public int? AreaId { get; set; }
        public int? PersonaId { get; set; }
        public int? TipoActivoId { get; set; }
        [DisplayName("Area")]
        public string NombreArea { get; set; }
        [DisplayName("Persona")]
        public string NombrePersona { get; set; }
        [DisplayName("Tipo de activo")]
        public string NombreTipoActivo { get; set; }
    }
}
