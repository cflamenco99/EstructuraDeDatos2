using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62011019_Proyecto1
{
    public class IndiceDetalleCasaDto
    {
        public IndiceDetalleCasaDto(int posicion, string codigoCasa)
        {
            this.NumeroRegistro = posicion;
            CodigoCasa = codigoCasa;
        }
        public int NumeroRegistro { get; set; }
        public string CodigoCasa { get; set; }
    }
}
