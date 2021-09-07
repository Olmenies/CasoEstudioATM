﻿//BaseDatosBanco.cs
//Representa la base de datos de información de las cuentas bancarias

public class BaseDatosBanco
{
    private Cuenta[] cuentas; //vector de cuentas bancarias

    //el contructor sin parámetros inicializa las cuentas
    public BaseDatosBanco()
    {
        //crea dos objetos Cuenta para prueba y los coloca en el vector Cuentas
        cuentas = new Cuenta[2]; //crea el vector Cuentas
        cuentas[0] = new Cuenta(12345, 54321, 1000.00M, 1200.00M);
        cuentas[1] = new Cuenta(98765, 56789, 200.00M, 200.00M);
    }//fin del constructor

    //obtiene un objeto Cuyenta que contiene el número de cuenta especificado
    private Cuenta ObtenerCuenta(int numeroCuenta)
    {
        //itera a través de cuentas, buscando un número de cuenta que coincida
        foreach(Cuenta cuentaActual in cuentas)
        {
            if (cuentaActual.NumeroCuenta == numeroCuenta)
                return cuentaActual;
        }//fin del foreach
        //no se encontró la cuenta
        return null;
    }//fin del método ObtenerCuenta

    public bool AutenticarUsuario(int numeroCuentaUsuario, int NIPUsuario)
    {
        //trata de obtener la cuenta con el número de cuenta
        Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);

        //si la cuenta existe, devuelve el resultado de la función ValidarNIP de Cuenta
        if (cuentaUsuario != null)
            return cuentaUsuario.ValidarNIP(NIPUsuario);//verdadero si coincide
        else
            return false;//no se encontró el número de cuenta, por lo que deuelve falso
    }//fin del método AutenticarUsuario

    //devuelve el saldo disponible de la Cuenta con el número de cuenta especificado
    public decimal ObtenerSaldoDisponible(int numeroCuentaUsuario)
    {
        Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
        return cuentaUsuario.SaldoDisponible;
    }//fin del método ObtenerSaldoDisponible

    //devuelve el saldo total de la Cuenta con el número de cuenta especificado
    public decimal ObtenerSaldoTotal(int numeroCuentaUsuario)
    {
        Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
        return cuentaUsuario.SaldoTotal;
    }//fin del método ObtenerSaldoTotal

    //abona a la Cuenta con el número de cuenta especificado
    public void Abonar(int numeroCuentaUsuario, decimal monto)
    {
        Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
        cuentaUsuario.Abonar(monto);
    }//fin del método Abonar

    //carga a la cuenta con el número de cuenta especificado
    public void Cargar(int numeroCuentaUsuario, decimal monto)
    {
        Cuenta cuentaUsuario = ObtenerCuenta(numeroCuentaUsuario);
        cuentaUsuario.Cargar(monto);
    }//fin del método Cargar
}//fin de la clase BaseDatosBanco