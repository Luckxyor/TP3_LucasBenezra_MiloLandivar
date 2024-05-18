public static class Tiquetera{
    private static Dictionary<int, Cliente> dicCliente=new Dictionary <int, Cliente>();
    private static int UltimoIDEntrada=0;
    public static int DevolverUltimoID(){
        return UltimoIDEntrada;
    }
    public static int AgregarCliente(Cliente cliente){
        UltimoIDEntrada++;
        SumarAbono(cliente.TipoEntrada, MiConsola.Abono(cliente.TipoEntrada,cliente.Cantidad));
        dicCliente.Add(UltimoIDEntrada,cliente);
        return UltimoIDEntrada;
    }
    public static Cliente BuscarCliente(int id){
        Cliente cliente=new Cliente();
        cliente= dicCliente[id];
        return cliente;
    }
    public static bool CambiarEntrada(int id, int tipoEntrada, int cantidad){
        bool sePudo=false;
        Cliente cliente= dicCliente[id];
        if(MiConsola.Abono(tipoEntrada,cantidad)>MiConsola.Abono(cliente.TipoEntrada, cliente.Cantidad)){
            sePudo=true;
            SumarAbono(tipoEntrada, MiConsola.Abono(tipoEntrada,cantidad));
            RestarAbono(cliente.TipoEntrada, MiConsola.Abono(cliente.TipoEntrada, cliente.Cantidad));
            cliente.TipoEntrada=tipoEntrada;
            cliente.Cantidad=cantidad;
            dicCliente[id]=cliente;
        }
        return sePudo;
    }    
    private static int AbonoTotal=0;
    private static int Abono1=0;
    private static int Abono2=0;
    private static int Abono3=0;
    private static int Abono4=0;

    private static void SumarAbono(int tipoEntrada, int abono){
        switch (tipoEntrada){
            case 1:
                AbonoTotal+=abono;
                Abono1+=abono;
            break;
            case 2:
                AbonoTotal+=abono;
                Abono2+=abono;
            break;
            case 3:
                AbonoTotal+=abono;
                Abono3+=abono;
            break;
            case 4:
                AbonoTotal+=abono;
                Abono4+=abono;
            break;
        }
    }
    private static void RestarAbono(int tipoEntrada, int abono){
        switch (tipoEntrada){
            case 1:
                AbonoTotal-=abono;
                Abono1-=abono;
            break;
            case 2:
                AbonoTotal-=abono;
                Abono2-=abono;
            break;
            case 3:
                AbonoTotal-=abono;
                Abono3-=abono;
            break;
            case 4:
                AbonoTotal-=abono;
                Abono4-=abono;
            break;
        }
    }

    public static void MostrarAbonos(){
        Console.WriteLine($"El abono total de fue ${AbonoTotal}");
        Console.WriteLine($"El abono de la entrada tipo '1' de fue ${Abono1}");
        Console.WriteLine($"El abono de la entrada tipo '2' de fue ${Abono2}");
        Console.WriteLine($"El abono de la entrada tipo '3' de fue ${Abono3}");
        Console.WriteLine($"El abono de la entrada tipo '4' de fue ${Abono4}");
    }

    public static List<string> EstadisticasTicketera= new List<string>();
}