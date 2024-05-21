public static class Tiquetera{
    private static Dictionary<int, Cliente> dicCliente=new Dictionary <int, Cliente>();
    private static int UltimoIDEntrada=0;
    public static int DevolverUltimoID(){
        return UltimoIDEntrada;
    }
    public static int AgregarCliente(Cliente cliente){
        UltimoIDEntrada++;
        SumarAbono(cliente.TipoEntrada, MiConsola.Abono(cliente.TipoEntrada,cliente.Cantidad));
        dicCliente.Add(UltimoIDEntrada, cliente);
        return UltimoIDEntrada;
    }
    public static Cliente BuscarCliente(int id){
        Cliente cliente=dicCliente[id];
        return cliente;
    }
    public static bool CambiarEntrada(int id, int tipoEntrada, int cantidad){
        bool sePudo=false;
        Cliente cliente=dicCliente[id];
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
        AbonoTotal+=abono;
        switch (tipoEntrada){
            case 1:
                Abono1+=abono;
            break;
            case 2:
                Abono2+=abono;
            break;
            case 3:
                Abono3+=abono;
            break;
            case 4:
                Abono4+=abono;
            break;
        }
    }
    private static void RestarAbono(int tipoEntrada, int abono){
        AbonoTotal-=abono;
        switch (tipoEntrada){
            case 1:
                Abono1-=abono;
            break;
            case 2:
                Abono2-=abono;
            break;
            case 3:
                Abono3-=abono;
            break;
            case 4:
                Abono4-=abono;
            break;
        }
    }
    public static List<string> EstadisticasTicketera= new List<string>();
    public static void IngresarLista(){
        int cantEnt1=0, cantEnt2=0, cantEnt3=0, cantEnt4=0, entradasTotal;
        EstadisticasTicketera.Clear();
        foreach(Cliente valor in dicCliente.Values){
            switch (valor.TipoEntrada){
            case 1:
                cantEnt1++;
            break;
            case 2:
                cantEnt2++;
            break;
            case 3:
                cantEnt3++;
            break;
            case 4:
                cantEnt4++;
            break;
            }
        }
        entradasTotal=cantEnt1+cantEnt2+cantEnt3+cantEnt4;
        double porc1= (cantEnt1/dicCliente.Count)*100;
        double porc2= (cantEnt2/dicCliente.Count)*100;
        double porc3= (cantEnt3/dicCliente.Count)*100;
        double porc4= (cantEnt4/dicCliente.Count)*100;
        EstadisticasTicketera.Add($"La cantidad de clientes inscriptos es de {dicCliente.Count}");
        EstadisticasTicketera.Add($"La cantidad de clientes que compraron la entrada tipo '1' fue de: {cantEnt1} | La cantidad de clientes que compraron la entrada tipo '2' fue de: {cantEnt2} | La cantidad de clientes que compraron la entrada tipo '3' fue de: {cantEnt3} | La cantidad de clientes que compraron la entrada tipo '4' fue de: {cantEnt4}");
        EstadisticasTicketera.Add($"El porcentaje de entradas compradas tipo '1' con respecto del total es del {porc1}% | El porcentaje de entradas compradas tipo '2' con respecto del total es del {porc2}% | El porcentaje de entradas compradas tipo '3' con respecto del total es del {porc3}% | El porcentaje de entradas compradas tipo '4' con respecto del total es del {porc4}%");
        EstadisticasTicketera.Add($"La recaudación de la entrada tipo '1' fue de ${Abono1} | La recaudación de la entrada tipo '2' fue de ${Abono2} | La recaudación de la entrada tipo '3' fue de ${Abono3} | La recaudación de la entrada tipo '4' fue de ${Abono4}");
        EstadisticasTicketera.Add($"La recaudación total fue de ${AbonoTotal}");
    }
}