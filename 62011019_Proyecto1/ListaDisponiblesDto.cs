using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62011019_Proyecto1
{
    public class ListaDisponiblesDto
    {
        public ListaDisponiblesDto(int numeroRegistro, int tamaño)
        {
            NumeroRegistro = numeroRegistro;
            Tamaño = tamaño;
        }
        public int NumeroRegistro { get; set; }
        public int Tamaño { get; set; }
    }
}
