using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62011019_Proyecto1
{
    public class ListaDisponiblesDto
    {
        public ListaDisponiblesDto(int posicion, string campoLlave)
        {
            Posicion = posicion;
            CampoLlave = campoLlave;
        }

        public int Posicion { get; set; }
        public string CampoLlave { get; set; }
    }
}
