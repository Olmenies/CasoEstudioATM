//Teclado.cs
//Representa el teclado del ATM

using System;

public class Teclado
{
    //devuelve un valor entero introducido por el usuario
    public int ObtenerEntrada()
    {
        return Convert.ToInt32(Console.ReadLine());
    }//fin del método ObtenerEntrada
}//fin de la clase Teclado