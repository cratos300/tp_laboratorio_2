using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string numero)
        {
            if (numero != "+" && numero != "*" && numero != "-" && numero != "/")
            {
                numero = "+";
            }
            return numero;
        }
        public double Operador(Numero n1, Numero n2, string operador)
        {

            string dato = operador;
            operador = ValidarOperador(operador);
            double devolver = 0;
            switch (operador)
            {
                case "*":
                    devolver = n1 * n2;
                    break;
                case "/":
                    devolver = n1 / n2;
                   if(double.IsInfinity(devolver))
                    {
                        devolver = double.MinValue;
                    }
                    break;
                case "+":
                    devolver = n1 + n2;
                    break;
                case "-":
                    devolver = n1 - n2;
                    break;
                default:
                    break;
            }
            return devolver;
        }

    }
}
