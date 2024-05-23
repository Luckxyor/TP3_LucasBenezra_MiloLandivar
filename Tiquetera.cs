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
        Cliente cliente=new Cliente();
        if (dicCliente.ContainsKey(id)){
            cliente=dicCliente[id];
        }
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
    public static List<string> EstadisticasTicketera(){
        int cantEnt1=0, cantEnt2=0, cantEnt3=0, cantEnt4=0, clien1=0, clien2=0, clien3=0, clien4=0, entradasTotal;
        List<string> estadisticas = new List<string>();
        foreach(Cliente cliente in dicCliente.Values){
            switch (cliente.TipoEntrada){
            case 1:
                cantEnt1+=cliente.Cantidad;
                clien1++;
            break;
            case 2:
                cantEnt2+=cliente.Cantidad;
                clien2++;
            break;
            case 3:
                cantEnt3+=cliente.Cantidad;
                clien3++;
            break;
            case 4:
                cantEnt4+=cliente.Cantidad;
                clien4++;
            break;
            }
        }
        int[] clientesArr = {clien1, clien2, clien3, clien4};
        int[] entradas = {cantEnt1, cantEnt2, cantEnt3, cantEnt4};
        int[] abonos={Abono1,Abono2,Abono3,Abono4};
        entradasTotal=cantEnt1+cantEnt2+cantEnt3+cantEnt4;
        estadisticas.Add($"La cantidad de clientes inscriptos es de: {dicCliente.Count}");
        for(int i=0; i<4; i++){
            estadisticas.Add($"La cantidad de clientes que compraron la entrada tipo '{i+1}' fue de: {clientesArr[i]}");
            if(entradas[i]>0){
                estadisticas.Add($"El porcentaje de entradas compradas tipo '{i+1}' con respecto del total es del " + entradas[i]*100/entradasTotal + "%"); 
            }
            estadisticas.Add($"La recaudación de la entrada tipo '{i+1}' fue de ${abonos[i]}");
        }
        estadisticas.Add($"La recaudación total fue de ${AbonoTotal}");
        return estadisticas;
    }
}