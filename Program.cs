using System.Collections.Generic;
namespace TP3_LucasBenezra_MiloLandivar;

class Program
{
    static void Main(string[] args)
    {
        int opcion;
        do{
            opcion = Menu();
            Console.WriteLine();
            switch (opcion)
            {
                case 1:
                    NuevaInscripcion();
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
    static int Menu(){
        Console.WriteLine();
        Console.WriteLine("1) Nueva Inscripción");
        Console.WriteLine("2) Obtener Estadísticas del Evento");
        Console.WriteLine("3) Buscar Cliente");
        Console.WriteLine("4) Cambiar entrada de un Cliente");
        Console.WriteLine("5) Salir");
        int opcion=MiConsola.LeerInt("Seleccione una opción: ");
        return opcion;
    }
    static void NuevaInscripcion(){
        Cliente cliente=new Cliente();
        string apellido, nombre;
        int dni, tipoEntrada, cantidad, abonar;
        do{
            dni=MiConsola.LeerInt("Ingrese el DNI");
        }while(dni<1);
        apellido=MiConsola.LeerString("Ingrese el Apellido");
        nombre=MiConsola.LeerString("Ingrese el Nombre");
        do{
            tipoEntrada=MiConsola.LeerInt("Ingrese el Tipo de Entrada");
        }while(tipoEntrada<1||tipoEntrada>4);
        do{
            cantidad=MiConsola.LeerInt("Ingrese la cantidad");
        }while(cantidad<1);

        abonar=MiConsola.Abono(tipoEntrada, cantidad);
        Console.WriteLine($"Cantidad a abonar: ${abonar}");
        cliente.ModificarPriv(dni,apellido,nombre);
        cliente.FechaInscripcion=DateTime.Now;
        cliente.TipoEntrada=tipoEntrada;
        cliente.Cantidad=cantidad;
        int id=Tiquetera.AgregarCliente(cliente);
        Console.WriteLine($"Se ha creado el nuevo Cliente con ID de entrada: {id}");
    }
    static void EstadisticasEvento(){
        if(Tiquetera.DevolverUltimoID()>0){
            List<string> lista= Tiquetera.EstadisticasTicketera();
            foreach(string estadistica in lista){
                Console.WriteLine(estadistica);
                Console.WriteLine();
            }
        }
        else{Console.WriteLine("Aún no se anotó nadie");}
    }
    static void BuscarCliente(){
        int id=MiConsola.LeerInt("Ingrese el ID de Entrada a buscar");
        Cliente cliente= Tiquetera.BuscarCliente(id);
        if(cliente!=null){
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
        bool sePudo;
        int id, tipoEntrada, cantidad;
        id=MiConsola.LeerInt("Ingrese el ID");
        do{
            tipoEntrada=MiConsola.LeerInt("Ingrese el Tipo de Entrada");
        }while(tipoEntrada<1||tipoEntrada>4);
        do{
            cantidad=MiConsola.LeerInt("Ingrese la cantidad");
        }while(cantidad<1);
        sePudo=Tiquetera.CambiarEntrada(id, tipoEntrada, cantidad);
        Console.WriteLine($"Se pudo cambiar la entrada={sePudo}");
    }
}