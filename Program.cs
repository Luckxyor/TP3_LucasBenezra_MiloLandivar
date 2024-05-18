using System.Collections.Generic;
namespace TP3_LucasBenezra_MiloLandivar;

class Program
{
    static void Main(string[] args)
    {
        Cliente cliente=new Cliente();
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
                    NuevaInscripcion(cliente);
                    break;
                case 2:
                    EstadisticasEvento();
                    break;
                case 3:
                    BuscarCliente();
                    break;
                case 4:
                    CambiarEntrada();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }while (opcion!=5);
    }
    static void NuevaInscripcion(Cliente cliente){
        string apellido, nombre, leer;
        int dni, tipoEntrada, cantidad, abonar;
        bool funciona;
        do{
            leer=MiConsola.Leer("Ingrese el DNI");
            funciona=int.TryParse(leer, out dni);
        }while(funciona==false||dni<1);
        do{
            leer=MiConsola.Leer("Ingrese el Apellido");
            apellido=leer;
        }while(apellido==null);
        do{
            leer=MiConsola.Leer("Ingrese el Nombre");
            nombre=leer;
        }while(nombre==null);
        do{
            leer=MiConsola.Leer("Ingrese el Tipo de Entrada");
            funciona=int.TryParse(leer, out tipoEntrada);
        }while(funciona==false||tipoEntrada<1||tipoEntrada>4);
        do{
            leer=MiConsola.Leer("Ingrese la cantidad");
            funciona=int.TryParse(leer, out cantidad);
        }while(funciona==false||cantidad<1);

        abonar=MiConsola.Abono(tipoEntrada, cantidad);
        Console.WriteLine($"Cantidad a abonar $: {abonar}");

        cliente.ModificarPriv(dni,apellido,nombre);
        cliente.FechaInscripcion=DateTime.Now;
        cliente.TipoEntrada=tipoEntrada;
        cliente.Cantidad=cantidad;
        int id=Tiquetera.AgregarCliente(cliente);
        Console.WriteLine($"Se ha creado el nuevo Cliente con ID de entrada: {id}");
        Console.WriteLine(Tiquetera.DevolverUltimoID());
    }
    static void EstadisticasEvento(){

    }
    static void BuscarCliente(){
        int id;
        bool funciona;
        string leer=MiConsola.Leer("Ingrese el ID de Entrada a buscar");
        funciona=int.TryParse(leer, out id);
        if(funciona||id>0){
            Cliente cliente= Tiquetera.BuscarCliente(id);
            Console.WriteLine($"El DNI es: {cliente.DNI}");
            Console.WriteLine($"El Nombre es: {cliente.Nombre}");
            Console.WriteLine($"El Apellido es: {cliente.Apellido}");
            Console.WriteLine($"La Fecha de inscripción es: {cliente.FechaInscripcion}");
            Console.WriteLine($"El tipo de entrada es: {cliente.TipoEntrada}");
            Console.WriteLine($"La cantidad que compró fue de: {cliente.Cantidad}");
        }
        else{Console.WriteLine("No existe ese ID de Entrada");}
    }
    static void CambiarEntrada(){
        bool sePudo, funciona;
        string leer;
        int id, tipoEntrada, cantidad;
        do{
            leer=MiConsola.Leer("Ingrese el ID");
            funciona=int.TryParse(leer, out id);
        }while(funciona==false||id<1||id>Tiquetera.DevolverUltimoID());
        do{
            leer=MiConsola.Leer("Ingrese el Tipo de Entrada");
            funciona=int.TryParse(leer, out tipoEntrada);
        }while(funciona==false||tipoEntrada<1||tipoEntrada>4);
        do{
            leer=MiConsola.Leer("Ingrese la cantidad");
            funciona=int.TryParse(leer, out cantidad);
        }while(funciona==false||cantidad<1);
        sePudo=Tiquetera.CambiarEntrada(id, tipoEntrada, cantidad);
        Console.WriteLine($"Se pudo cambiar la entrada={sePudo}");
    }
}