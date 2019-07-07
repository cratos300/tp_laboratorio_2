using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;


        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Muestro los datos de un alumno esta funcion luego se usa en tostring por que en la misma es protected
        /// </summary>
        /// <returns></returns> devuelvo string
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat("\nEstado de cuenta : {0}", this.estadoCuenta.ToString() + this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Muestro el atributo clasequetoma en string
        /// </summary>
        /// <returns></returns> string
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nTOMA CLASE DE " + this.claseQueToma.ToString());
            return sb.ToString();
        }
        /// <summary>
        ///  utilizo el metodo participarEnClases y mostrarDatos y lo hago "publico" para utilizarlo
        /// </summary>
        /// <returns></returns> devuelvo string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(this.MostrarDatos());
            return sb.ToString();
        }
        /// <summary>
        /// Comparo un alumno con un dato de tipo eclases
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="c1"></param>
        /// <returns></returns> retorno booleano
        public static bool operator ==(Alumno a1, Universidad.EClases c1)
        {
            bool retorno = false;
            if (a1.claseQueToma == c1 && a1.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Comparo un alumno con un dato de tipo eclases
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="c1"></param>
        /// <returns></returns> retorno booleano
        public static bool operator !=(Alumno a1, Universidad.EClases c1)
        {
            bool retorno = false;
            if (a1.claseQueToma != c1)
            {
                retorno = true;
            }
            return retorno;
        }






    }
}
