using _62011019_Proyecto1;
funciones acciones = new funciones();
int centinela = 0;

Console.WriteLine("*********************************************************************************");
Console.WriteLine("Detalle de casas - administrador de archivo de datos - Carlos Flamenco - 62011019");
Console.WriteLine("*********************************************************************************");
Console.WriteLine("MENU DE OPCIONES");
Console.WriteLine("1. Leer registros");
Console.WriteLine("2. Ingresar registro");
Console.WriteLine("3. Eliminar registro");
Console.WriteLine("4. Mostrar lista de disponibles");
Console.WriteLine("5. Compactar espacio");
Console.WriteLine("6. Mostrar indice primario");
Console.WriteLine("7. Salir");
Console.WriteLine("*********************************************************************************");

while(centinela == 0)
{
    Console.Write("Numero de opcion a elegir: ");
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            acciones.LeerRegistros();
            break;
        case "2":
            acciones.InsertarRegistro();
            break;
        case "3":
            acciones.EliminarRegistro();
            break;
        case "4":
            acciones.LeerListaDisponibles();
            break;
        case "5":
            acciones.CompactarArchivoDeDatos();            
            break;
        case "6":
            acciones.LeerIndice();
            break;
        case "7":
            centinela++;
            break;
        default:
            Console.WriteLine("Ha ingresado una opcion invalida.");
            break;
    }
}
Console.WriteLine("*********************************************************************************");