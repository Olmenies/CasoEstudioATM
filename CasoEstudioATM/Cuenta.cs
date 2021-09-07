//Cuenta.cs
//La clase Cuenta representa una cuenta bancaria

public class Cuenta
{
    private int numeroCuenta; //número de cuenta
    private int nip; //NIP para autenticación
    private decimal saldoDisponible; //monto disponible para retiro
    private decimal saldoTotal; //fondos disponibles + depósito pendiente

    //el contructor de cuatro parámetros inicializa los atributos
    public Cuenta(int elNumeroCuenta, int elNIP, decimal elSaldoDisponible, decimal elSaldoTotal)
    {
        numeroCuenta = elNumeroCuenta;
        nip = elNIP;
        saldoDisponible = elSaldoDisponible;
        saldoTotal = elSaldoTotal;
    }//fin del constructor

    //propiedod de sólo lectura que obtiene el número de cuenta
    public int NumeroCuenta
    {
        get
        {
            return numeroCuenta;
        }//fin del get
    }//fin de la propiedad NumerCuenta

    //propiedad de sólo lectura que obtiene el saldo disponible
    public decimal SaldoDisponible
    {
        get
        {
            return saldoDisponible;
        }//fin del get
    }//fin de la propiedad SaldoDisponible

    //propiedad de sólo lectura que obtiene el saldo total
    public decimal SaldoTotal
    {
        get
        {
            return saldoTotal;
        }//fin del get
    }//fin de la propiedad SaldoTotal

    //determina si un NIP especificando por el usuario coinicide con un NIP en Cuenta
    public bool ValidarNIP(int NIPUsuario)
    {
        return (NIPUsuario == nip);
    }//fin del método validarNIP

    //abona a la cuenta (los fondos no se han verificado todavía)
    public void Abonar(decimal monto)
    {
        saldoTotal += monto; //lo suma al saldo total
    }//fin del método Abonar

    //carga a la cuenta
    public void Cargar(decimal monto)
    {
        saldoDisponible -= monto; //lo resta del saldo disponible
        saldoTotal -= monto; //lo resta del saldo total
    }//fin del método Cargar
}//fin de la clase Cuenta