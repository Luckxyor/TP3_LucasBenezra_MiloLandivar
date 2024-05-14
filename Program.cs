using System.Collections.Generic;
namespace TP3_LucasBenezra_MiloLandivar;

class Program
{
    static void Main(string[] args)
    {
        int opcion;
        do{
            Console.WriteLine();
            Console.WriteLine("1) Nueva Inscripción");
            Console.WriteLine("2) Obtener Estadísticas del Evento");
            Console.WriteLine("3) Buscar Cliente");
            Console.WriteLine("4) Cambiar entrada de un Cliente");
            Console.WriteLine("5) Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (opcion)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }while (opcion!=5);
    }
}
