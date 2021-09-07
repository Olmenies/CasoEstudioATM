//Deposito.cs
//Representa una transacción de depósito en el ATM

public class Deposito : Transaccion
{
    private decimal monto; //monto a depositar
    private Teclado teclado; //referencia al Teclado
    private RanuraDeposito ranuraDeposito; //referencia a la ranura de depósito

    //constante que representa la opción de cancelar
    private const int CANCELO = 0;

    //constructor de cinco parámetros que inicializa las variables de instancia de la clase
    public Deposito(int numeroCuentaUsuario, Pantalla pantallaATM, BaseDatosBanco baseDatosBancoATM, Teclado tecladoATM, RanuraDeposito ranuraDepositoATM)
        :base(numeroCuentaUsuario, pantallaATM, baseDatosBancoATM)
    {
        //inicializa las referencias al teclado y a la ranura de depósito
        teclado = tecladoATM;
        ranuraDeposito = ranuraDepositoATM;
    }//fin del constructor de cinco parámetros

    //realiza una transacción; redefine el método abstracto de Transacción
    public override void Ejecutar()
    {
        monto = PedirMontoADepositar(); //obtiene el monto a depositar del usuario

        //comprueba si el usuario introdujo un monto a depositar o si canceló
        if (monto != CANCELO)
        {
            //solicita un sobre de depósito que contenga el monto especificado
            PantallaUsuario.MostrarMensaje("\nIntroduzca un sobre de depósito que contenga: ");
            PantallaUsuario.MostrarMontoEnDolares(monto);
            PantallaUsuario.MostrarLineaMensaje(" en la ranura para depósitos.");

            //obtiene el sobre de depósito
            bool sobreRecibido = ranuraDeposito.SeRecibioSobreDeposito();

            //comprueba si se recibió el sobre de dedpósito
            if (sobreRecibido)
            {
                PantallaUsuario.MostrarLineaMensaje("\nSe recibió su sobre.\nEl dinero que acaba de depositar no estará disponible sino hasta que \n" +
                    "verifiquemos el monto del efectivo dentro del sobrey que se haya verificado cualquier cheque incluído.");

                //abona a la cuenta para reflejar el depósito
                BaseDatos.Abonar(NumeroCuenta, monto);
            }//fin del if interno
            else
                PantallaUsuario.MostrarLineaMensaje("\nNo insertó un sobre, por lo que el ATM ha cancelado su transacción.");
        }//fin del if externo
        else
            PantallaUsuario.MostrarLineaMensaje("Cancelando la transacción...");
    }//fin del método Ejecutar()

    //pide al usuarioq ue introduzca un monto de depósito para abonarlo a la cuenta
    private decimal PedirMontoADepositar()
    {
        //muestra el indicador y reciba la entrada
        PantallaUsuario.MostrarMensaje("\nIntroduzca un monto a depositar en CENTAVOS ( o 0 para cancelar ): ");
        int entrada = teclado.ObtenerEntrada();

        //comprueba si el usuario canceló o introdujo un monto válido
        if (entrada == CANCELO)
            return CANCELO;
        else
            return entrada / 100.00M;
    }//fin del método PedirMontoADepositar
}//fin de la clase Depósito