using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            this.MyProperty = numero;
        }
        public double ValidarNumero(string numero)
        {
            double dato;
            double.TryParse(numero, out dato);
            return dato;
        }
        private string MyProperty
        {

            set
            {
                double devolver;
                devolver = ValidarNumero(value);
                    this.numero = devolver;
                
            }
        }
        public static double operator -(Numero n1, Numero n2)
        {
            double retornar = 0;
            if(n1!=null && n2 != null)
            {
                retornar = n1.numero - n2.numero;
            }
            return retornar;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            double retornar = 0;
            if (n1 != null && n2 != null)
            {
                retornar = n1.numero + n2.numero;
            }
            return retornar;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double retornar = 0;
            if (n1 != null && n2 != null)
            {      
                    retornar = n1.numero / n2.numero; 
            }
            return retornar;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            double retornar = 0;
            if (n1 != null && n2 != null)
            {
                retornar = n1.numero * n2.numero;
            }
            return retornar;
        }
        public string BinarioDecimal(string binario)
        {
            int i;
            int dato = 0;
            string retornar = "";

            foreach (char caracter in binario)
                if (caracter != '0' && caracter != '1')
                    return "valor no es correcto";

            if (binario == "" || ReferenceEquals(binario, null))
            {
                retornar = "valor invalido";
            }
            else
            {
                for (i = 1; i <= binario.Length; i++)
                {
                    dato += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
                }
                retornar = dato.ToString();
            }

            return retornar;
        }
        public string DecimalBinario(double numero)
        {
            string devolver;
            devolver = this.DecimalBinario(numero.ToString());
            return devolver;
        }
        public string DecimalBinario(string binario)
        {
            int numero;
            string returnValue = "";

            if (int.TryParse(binario, out numero))
            {
                while (numero > 0)
                {
                    returnValue = (numero % 2).ToString() + returnValue;
                    numero = numero / 2;
                }
            }
            else
                returnValue = "valor invalido";

            return returnValue;
        }
    }
}
