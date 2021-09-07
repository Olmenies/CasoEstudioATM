//SolicitudSaldo.cs
//Representa una transacción de solicitud de saldo en el ATM

public class SolicitudSaldo : Transaccion
{
    //el constructor de cinco parámetros inicializa las variables de la clase base
    public SolicitudSaldo(int numeroCuentaUsuario, Pantalla pantallaATM, BaseDatosBanco BaseDatosBancoATM)
        : base(numeroCuentaUsuario, pantallaATM, BaseDatosBancoATM) { }

    //realiza una transacción; redefine el método abstracto de Transaccion
    public override void Ejecutar()
    {
        //obtiene el saldo disponible para la cuenta del usuario actual
        decimal saldoDisponible = BaseDatos.ObtenerSaldoDisponible(NumeroCuenta);

        //obtiene el saldo total para la Cuenta del usuario actual
        decimal saldoTotal = BaseDatos.ObtenerSaldoTotal(NumeroCuenta);

        //muestra la información del saldo en la pantalla
        PantallaUsuario.MostrarLineaMensaje("\nInformación del saldo: ");
        PantallaUsuario.MostrarMensaje(" - Saldo disponible: ");
        PantallaUsuario.MostrarMontoEnDolares(saldoDisponible);
        PantallaUsuario.MostrarMensaje(" - Saldo total:");
        PantallaUsuario.MostrarMontoEnDolares(saldoTotal);
        PantallaUsuario.MostrarLineaMensaje("");
    }//fin del método Ejecutar
}//fin de la clase SolicitudSaldo