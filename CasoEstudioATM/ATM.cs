//ATM.cs
//Representa a un cajero automático

public class ATM
{
    private bool usuarioAutenticado; //verdadero si el usuario es autenticado
    private int numeroCuentaActual; //número de cuneta del usuario
    private Pantalla pantalla; //referenecia a la pantalla del ATM
    private Teclado teclado; //referenci al teclado del ATM
    private DispensadorEfectivo dispensadorEfectivo; //referencia al dispensador de efectivo del ATM
    private RanuraDeposito ranuraDeposito; //referencia a la ranura de depósito del ATM
    private BaseDatosBanco baseDatosBanco; //referencia a la información de la base de datos de cuentas

    //enumeración que representa las opciones del menú principal
    private enum OpcionMenu
    {
        SOLICITUD_SALDO = 1,
        RETIRO = 2,
        DEPOSITO = 3,
        SALIR_ATM = 4
    }//fin de la enumeración OpcionMenu

    //el constructor sin parámentro inicializa las variables de instancia
    public ATM()
    {
        usuarioAutenticado = false; //al principio, el usuario no está autenticado
        numeroCuentaActual = 0; //al principio, no hay número de cuenta actual
        pantalla = new Pantalla(); //crea la pantalla
        teclado = new Teclado(); //crea el teclado
        dispensadorEfectivo = new DispensadorEfectivo(); //crea el dispensador de efectivo
        ranuraDeposito = new RanuraDeposito(); //crea la ranura de depósito
        baseDatosBanco = new BaseDatosBanco(); //crea la base de datos de información de las cuentas
    }//fin del constructor

    //inicia ATM
    public void Ejecutar()
    {
        //bienvenida y autentificación de usuario; realiza transacciones
        while (true) //ciclo infinito
        {
            //itera mientras el usuario no sea autentificado
            while(!usuarioAutenticado)
            {
                pantalla.MostrarLineaMensaje("\n¡Bienvenido!");
                AutenticarUsuario(); //autentica el usuario
            }//fin del while

            RealizarTransacciones(); //para el usuario autenticado
            usuarioAutenticado = false; //se reestablece antes de la siguiente sesión con el ATM
            numeroCuentaActual = 0; //se reestablece antes de la siguiente sesión con el ATM
            pantalla.MostrarLineaMensaje("\n¡Gracias! ¡Adios!"); 
        }//fin del while
    }//fin del método Ejecutar

    //trata de autenticar al usuario con la base de datos
    private void AutenticarUsuario()
    {
        //pide el número de cuenta y lo recibe como entrada del usuario
        pantalla.MostrarMensaje("\nIntroduzca su número de cuenta: ");
        int numeroCuenta = teclado.ObtenerEntrada();

        //pide el NIP y lo recibe como entrada del usuario
        pantalla.MostrarMensaje("\nIntroduzca su NIP: ");
        int pin = teclado.ObtenerEntrada();

        //establece usuarioAutenticado al valor booleano devuelto por la base de datos 
        usuarioAutenticado = baseDatosBanco.AutenticarUsuario(numeroCuenta, pin);

        //verifica si se realizó la autenticación con éxito
        if (usuarioAutenticado)
            numeroCuentaActual = numeroCuenta;
        else
            pantalla.MostrarLineaMensaje("\nNúmero de cuenta o NIP inválido. Intente de nuevo.");
    }//fin del método AutenticarUsuario

    //muestra el menú principal y realiza las transacciones
    private void RealizarTransacciones()
    {
        Transaccion transaccionActual; //la transacción que se está procesando
        bool usuarioSalio = false; //el usuario no ha elegido salir

        //itera mientras el usuario no elija la opción para salir
        while (!usuarioSalio)
        {
            //muestra el menú principal y obtiene la selección del usuario
            int seleccionMenuPrincipal = MostrarMenuPrincipal();

            //decide cómo proceder, con base en la selección del menú del usuario
            switch((OpcionMenu) seleccionMenuPrincipal)
            {
                //el usuario elige realizar uno de los tres tipos de transacciones
                case OpcionMenu.SOLICITUD_SALDO:
                case OpcionMenu.RETIRO:
                case OpcionMenu.DEPOSITO:
                    //se inicializa como nuevo objeto del tipo elegido
                    transaccionActual = CrearTransaccion(seleccionMenuPrincipal);
                    transaccionActual.Ejecutar(); //ejecuta la transacción
                    break;
                case OpcionMenu.SALIR_ATM: //el usuario eligió terminar la sesión
                    pantalla.MostrarLineaMensaje("\nSaliendo del sistema...");
                    usuarioSalio = true; //esta sesión con el ATM debe terminar
                    break;
            }//fin del switch
        }//fin del while
    }//fin del método RealizarTransacciones

    //muestra el menú principal y devuelve una selección de entrada
    private int MostrarMenuPrincipal()
    {
        pantalla.MostrarLineaMensaje("\nMenú principal: ");
        pantalla.MostrarLineaMensaje("1 - Ver mi saldo");
        pantalla.MostrarLineaMensaje("2 - Retirar efectivo");
        pantalla.MostrarLineaMensaje("3 - Depositar fondos");
        pantalla.MostrarLineaMensaje("4 - Salir\n");
        pantalla.MostrarLineaMensaje("Introduzca una opción: ");
        return teclado.ObtenerEntrada(); //devuelve la selección del usuario
    }//fin del método MostrarMenuPrincipal

    //devuelve un objeto de la clase especifiada, derivada de Transacción
    private Transaccion CrearTransaccion(int tipo)
    {
        Transaccion temp = null; //referencia a Transacción nula

        //determina el tipo de transacción que va a crear
        switch((OpcionMenu) tipo)
        {
            //crea nueva transaccion SolicitudSaldo
            case OpcionMenu.SOLICITUD_SALDO:
                temp = new SolicitudSaldo(numeroCuentaActual, pantalla, baseDatosBanco);
                break;

            //crea nueva transacción Retiro
            case OpcionMenu.RETIRO:
                temp = new Retiro(numeroCuentaActual, pantalla, baseDatosBanco, teclado, dispensadorEfectivo);
                break;

            //crea nueva transaccion Depósito
            case OpcionMenu.DEPOSITO:
                temp = new Deposito(numeroCuentaActual, pantalla, baseDatosBanco, teclado, ranuraDeposito);
                break;
        }//fin del switch
        return temp;
    }//fin del método CrearTransaccion
}//fin de la clase ATM