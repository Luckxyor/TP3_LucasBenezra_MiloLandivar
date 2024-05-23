public static class MiConsola{
    public static string LeerString(string mensaje){
        string leer;
        do{
            Console.WriteLine(mensaje);
            leer=Console.ReadLine();
            return leer;
        }while(leer=="");
    }
    public static int LeerInt(string mensaje){
        bool Pude = false;
        int valor = 0;
        while (!Pude)
        {
            Console.WriteLine(mensaje);
            Pude = int.TryParse(Console.ReadLine(), out valor);
        }
        return valor;
    }
    public static int Abono(int tipoEntrada, int cantidad){
        int abono=0;
        switch (tipoEntrada){
            case 1:
                abono=45000*cantidad;
            break;
            case 2:
                abono=60000*cantidad;
            break;
            case 3:
                abono=30000*cantidad;
            break;
            case 4:
                abono=100000*cantidad;
            break;
        }
        return abono;
    }
}