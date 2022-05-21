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
        private static int CantidadMaximaCaracteresPorRegistro => 30;
        private static string RutaArchivoDatos => $"../../../Proyecto1.txt";
        private static string RutaArchivoIndice => $"../../../Indice.txt";
        private static string RutaArchivoListaDisponibles => $"../../../Disponibles.txt";
        public List<DetalleCasaDto> ListadoDatos { get; set; } = new List<DetalleCasaDto>();
        public List<IndiceDetalleCasaDto> IndiceListadoDatos { get; set; } = new List<IndiceDetalleCasaDto>();
        public List<ListaDisponiblesDto> ListaDisponiblesDatos { get; set; } = new List<ListaDisponiblesDto>();
        public funciones()
        {
        }
        public void ActualizarDatosEnMemoria()
        {
            if (ListadoDatos.Count > 0)
            {
                ListadoDatos.RemoveRange(0, ListadoDatos.Count);
            }

            string[] filas = File.ReadAllLines(RutaArchivoDatos);
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
                    obj[6],
                    bool.Parse(obj[7])
                    );
                ListadoDatos.Add(registro);
            }
        }
        public void ActualizarDatosEnMemoriaIndice()
        {
            if (IndiceListadoDatos.Count > 0)
            {
                IndiceListadoDatos.RemoveRange(0, IndiceListadoDatos.Count);
            }

            string[] filas = File.ReadAllLines(RutaArchivoIndice);
            foreach (string fi in filas)
            {
                string[] obj = fi.Split('/');
                IndiceDetalleCasaDto registro = new IndiceDetalleCasaDto(
                    int.Parse(obj[0]),
                    obj[1]
                    );
                IndiceListadoDatos.Add(registro);
            }
        }
        public void ActualizarDatosEnMemoriaListaDisponibles()
        {
            if (ListaDisponiblesDatos.Count > 0)
            {
                ListaDisponiblesDatos.RemoveRange(0, ListaDisponiblesDatos.Count);
            }

            string[] filas = File.ReadAllLines(RutaArchivoListaDisponibles);
            foreach (string fi in filas)
            {
                string[] obj = fi.Split('/');
                ListaDisponiblesDto registro = new ListaDisponiblesDto(
                    int.Parse(obj[0]),
                    int.Parse(obj[1])
                    );
                ListaDisponiblesDatos.Add(registro);
            }
        }
        public void LeerRegistros()
        {
            ActualizarDatosEnMemoria();
            if (ListadoDatos.Count > 0)
            {
                ConsoleTable.From(ListadoDatos).Write();
            }
            else
            {
                Console.WriteLine("No hay registros.");
                return;
            }
            
            Console.WriteLine("*********************************************************************************");

            Console.WriteLine("¿Si desea navegar hacia un registro en especifico? Ingrese 1 si no presione cualquier otro boton: ");
            var decision = Console.ReadLine();

            if(decision == "1")
            {
                Console.WriteLine("Ingrese el codigo de casa a buscar: ");
                var codigo = Console.ReadLine();

                var indice = IndiceListadoDatos.Where(x => x.CodigoCasa == codigo).FirstOrDefault();
                List<DetalleCasaDto> registro = new List<DetalleCasaDto>();
                registro.Add(ListadoDatos[indice.NumeroRegistro]);
                ConsoleTable.From(registro).Write();
            }
        }
        public void InsertarRegistro()
        {
            ActualizarDatosEnMemoria();
            Console.WriteLine("*********************************************************************************");
            Console.WriteLine("REGISTRO DE CASA");
            DetalleCasaDto nuevoRegistro = new DetalleCasaDto();

            Console.Write("Ingrese el codigo de casa: ");
            nuevoRegistro.CodigoCasa = Console.ReadLine();

            Console.Write("Ingrese el codigo de proyecto residencial de la casa: ");
            nuevoRegistro.CodigoProyectoResidencial = Console.ReadLine();


            Console.Write("Ingrese la ubicacion o bloque de la casa: ");
            nuevoRegistro.Ubicacion = Console.ReadLine();


            Console.Write("Ingrese la cantidad de habitaciones de la casa: ");
            nuevoRegistro.CantidadHabitaciones = Console.ReadLine();


            Console.Write("Ingrese la cantidad de baños de la casa: ");
            nuevoRegistro.CantidadBaños = Console.ReadLine();


            Console.Write("Ingrese el precio de la casa: ");
            nuevoRegistro.Precio = Console.ReadLine();

            nuevoRegistro.Activo = true;

            RegistrarNuevoObjetoEnTxt(nuevoRegistro, false, 0);
            Console.WriteLine("Registro grabado exitosamente");
            Console.WriteLine("*********************************************************************************");            
        }
        private int ObtenerSiguientePosicionEnArcvhivo()
        {
            if (ListadoDatos == null || ListadoDatos.Count == 0) { return 1; }
            return ListadoDatos.Count + 1;
        }
        private void RegistrarNuevoObjetoEnTxt(DetalleCasaDto registro, bool registroPorEliminacion, int contador) 
        {
            using (StreamWriter sw = File.AppendText(RutaArchivoDatos))
            {
                int posicionSiguiente; ;
                if (registroPorEliminacion)
                {
                    posicionSiguiente = contador;
                }
                else
                {
                    posicionSiguiente = ObtenerSiguientePosicionEnArcvhivo();
                }
                
                sw.WriteLine($"{posicionSiguiente}/{registro.CodigoCasa}/{registro.CodigoProyectoResidencial}/{registro.Ubicacion}/{registro.CantidadHabitaciones}/{registro.CantidadBaños}/{registro.Precio}/{registro.Activo == true}");
            }            
        }
        public void EliminarRegistro()
        {
            ActualizarDatosEnMemoria();
            Console.WriteLine("*********************************************************************************");
            Console.Write("Ingrese el codigo de casa que desea eliminar: ");
            var codigo = Console.ReadLine();

            ListadoDatos.Find(x => x.CodigoCasa == codigo).Activo = false;
            LimpiarArchivoDatos();

            int contador = 0;
            foreach (var item in ListadoDatos)
            {
                contador++;
                RegistrarNuevoObjetoEnTxt(item, true, contador);
            }

            Console.WriteLine("*********************************************************************************");
        }
        private void LimpiarArchivoDatos()
        {
            File.WriteAllText(RutaArchivoDatos, string.Empty);
        }
        public void LeerListaDisponibles()
        {
            ActualizarDatosEnMemoriaListaDisponibles();
            if(ListaDisponiblesDatos.Count > 0)
            {
                ConsoleTable.From(ListaDisponiblesDatos).Write();
            }
            else
            {
                Console.WriteLine("No hay registros.");
            }            
        }
        public void LeerIndice()
        {
            ActualizarDatosEnMemoriaIndice();
            if (IndiceListadoDatos.Count > 0)
            {
                ConsoleTable.From(IndiceListadoDatos).Write();
            }
            else
            {
                Console.WriteLine("No hay registros.");
            }            
        }
        public void CompactarArchivoDeDatos()
        {
            ActualizarDatosEnMemoria();
            LimpiarArchivoDatos();
            List<DetalleCasaDto> nuevaListaDatos = ListadoDatos.Where(x => x.Activo).ToList();

            int contador = 0;
            foreach (var item in nuevaListaDatos)
            {
                contador++;
                RegistrarNuevoObjetoEnTxt(item, true, contador);
            }
        }
    }
}
