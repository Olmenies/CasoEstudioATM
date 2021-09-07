//Transacción.cs
//La clase base abstracta Transacción representa una transacción en el ATM

public abstract class Transaccion
{
    private int numeroCuenta; //cuenta involucrada en la transacción
    private Pantalla pantallaUsuario; //referencia a la pantalla del ATM
    private BaseDatosBanco baseDatos; //referencia a la base ded datos de información de cuentas

    //constructor de tres parámetros invocado por las clases derivadas
    public Transaccion (int cuentaUsuario, Pantalla laPantalla, BaseDatosBanco laBaseDatos)
    {
        numeroCuenta = cuentaUsuario;
        pantallaUsuario = laPantalla;
        baseDatos = laBaseDatos;
    }//fin del constructor

    //propiedad de sólo lectura que obtiene el número de cuenta
    public int NumeroCuenta
    {
        get
        {
            return numeroCuenta;
        }//fin del get
    }//fin de la porpiedad NumeroCuenta

    //propiedad de sólo lectura que obtiene la referencia a la pantalla
    public Pantalla PantallaUsuario
    {
        get
        {
            return pantallaUsuario;
        }//fin del get
    }//fin de la propiedad PantallaUsuario

    //propiedadde sólo lectura que obtiene la referencia a la base de datos del banco
    public BaseDatosBanco BaseDatos
    {
        get
        {
            return baseDatos;
        }//fin del get
    }//fin de la propiedad BaseDatosBanco

    //realiza la transacción (cada clase derivada lo redefine)
    public abstract void Ejecutar(); //no hay implementación acá
}//fin de la clase Transacción