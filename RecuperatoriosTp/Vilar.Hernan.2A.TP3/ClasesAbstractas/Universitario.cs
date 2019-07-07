using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        /// <summary>
        /// constructor sin parametro
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// constructor con parametros
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="n1"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad n1) : base(nombre, apellido, dni, n1)
        {

            this.legajo = legajo;

        }
        /// <summary>
        /// el equals compara si el objecto que recibo es del mismo tipo que del que lo estoy llamando(this)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns> bool
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Comparo si un universitario es igual a otro por legajo o dni y del mismo tipo
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns> bool
        public static bool operator ==(Universitario u1, Universitario u2)
        {
            bool retorno = false;
            if (u1.Equals(u2) && (u1.legajo == u2.legajo || u1.DNI == u2.DNI))// se cambio el parentesis del ||
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// comparo si un univesitario es distinto a otro reutilizando codigo con el metodo de arriba
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="u2"></param>
        /// <returns></returns> bool
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return (!(u1 == u2));
        }
        /// <summary>
        /// Muestro los datos de un universitario que es protegido para que solo puedan ver clases derivadas
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("legajo" + this.legajo);
            return sb.ToString();
        }
        /// <summary>
        /// clase protected y abstracta, no implementa funcionalidad, pero si obliga a que sus derivadas lo hagan.
        /// </summary>
        /// <returns></returns> devuelve un string
        protected abstract string ParticiparEnClase();
    }
}
