using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62011019_Proyecto1
{
    public class ListaDisponiblesDto
    {
        public ListaDisponiblesDto(string campoLlave, string posicion)
        {
            CampoLlave = campoLlave;
            Posicion = posicion;
        }
        public string CampoLlave { get; set; }
        public string Posicion { get; set; }
    }
}
