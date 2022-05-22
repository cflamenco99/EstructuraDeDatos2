namespace _62011019_Proyecto1
{
    public class DetalleCasaDto
    {
        public DetalleCasaDto()
        {
        }
        public DetalleCasaDto(string numeroRegistro, string codigoCasa, string codigoProyectoResidencial, string ubicacion, string cantidadHabitaciones, string cantidadBaños, string precio, bool activo)
        {
            CodigoCasa = codigoCasa;
            CodigoProyectoResidencial = codigoProyectoResidencial;
            Ubicacion = ubicacion;
            CantidadHabitaciones = cantidadHabitaciones;
            CantidadBaños = cantidadBaños;
            Precio = precio;
            Activo = activo;
            NumeroRegistro = numeroRegistro;
        }
        public string NumeroRegistro { get; set; }
        public string CodigoCasa { get; set; }
        public string CodigoProyectoResidencial { get; set; }
        public string Ubicacion { get; set; }
        public string CantidadHabitaciones { get; set; }
        public string CantidadBaños { get; set; }
        public string Precio { get; set; }
        public bool Activo { get; set; }
    }
}
