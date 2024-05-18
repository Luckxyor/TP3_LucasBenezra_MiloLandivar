public class Cliente{
    public int DNI{get; private set;}
    public string Apellido{get; private set;}
    public string Nombre{get; private set;}
    public DateTime FechaInscripcion {get; set;}
    public int TipoEntrada {get; set;}
    public int Cantidad {get; set;}
    public Cliente(){}
    public Cliente(DateTime fecha, int tipoEntrada, int cantidad){
        FechaInscripcion=fecha;
        TipoEntrada=tipoEntrada;
        Cantidad=cantidad;
    }
    public void ModificarPriv(int dni, string apellido, string nombre){
        DNI=dni;
        Apellido=apellido;
        Nombre=nombre;
    }
}