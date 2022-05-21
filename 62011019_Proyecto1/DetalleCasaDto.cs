namespace _62011019_Proyecto1
{
    public class DetalleCasaDto
    {
        public DetalleCasaDto(string codigoCasa, string codigoProyectoResidencial, string ubicacion, string cantidadHabitaciones, string cantidadBaños, string precio, bool activo)
        {
            CodigoCasa = codigoCasa;
            CodigoProyectoResidencial = codigoProyectoResidencial;
            Ubicacion = ubicacion;
            CantidadHabitaciones = cantidadHabitaciones;
            CantidadBaños = cantidadBaños;
            Precio = $"L. {precio}";
            Activo = activo;
        }

        public string CodigoCasa { get; set; }
        public string CodigoProyectoResidencial { get; set; }
        public string Ubicacion { get; set; }
        public string CantidadHabitaciones { get; set; }
        public string CantidadBaños { get; set; }
        public string Precio { get; set; }
        public bool Activo { get; set; }
    }
}
