using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace _62011019_Proyecto1
{
    public class funciones
    {
        public funciones()
        {
        }
        private static int CantidadFijaCaracteres => 10;
        public void LeerRegistros()
        {
            List<DetalleCasaDto> listado = new List<DetalleCasaDto>();
            string FileToRead = $"../../../Proyecto1.txt";
            // Creating string array  
            string[] filas = File.ReadAllLines(FileToRead);
            foreach (string fi in filas)
            {
                string[] obj = fi.Split('/');
                DetalleCasaDto registro = new DetalleCasaDto(
                    obj[0],
                    obj[1],
                    obj[2],
                    obj[3],
                    obj[4],
                    obj[5],
                    bool.Parse(obj[6])
                    );
                listado.Add(registro);
            }
            ConsoleTable.From(listado).Write();
            Console.WriteLine("*********************************************************************************");
        }

    }
}
