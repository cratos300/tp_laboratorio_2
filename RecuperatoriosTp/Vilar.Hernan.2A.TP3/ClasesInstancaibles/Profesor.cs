using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        public static Random random;

        static Profesor()
        {
            random = new Random();
        }
        public Profesor()
        {
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this.randomClases();

        }
        /// <summary>
        /// Retorno los datos para luego usarlo en el tostring por que es protected.
        /// </summary>
        /// <returns></returns> string
        protected override string MostrarDatos()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(base.MostrarDatos());
            //sb.AppendLine("Las clases del dia son :");
            //foreach (Universidad.EClases e in this.clasesDelDia)
            //{
            //    sb.AppendLine(e.ToString());
            //}
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(clasesDelDia.Peek().ToString());
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// utilizo el metodo mostrar dentro del tostring por que tostring es publico 
        /// </summary>
        /// <returns></returns> string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.MostrarDatos());
            return sb.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASES DEL DIA:");
            foreach (Universidad.EClases c1 in clasesDelDia)
            {
                sb.AppendLine(c1.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// comparo un profesor con un dato de ti po eclases
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="e1"></param>
        /// <returns></returns> bool
        public static bool operator ==(Profesor p1, Universidad.EClases e1)
        {
            bool retorno = false;
            foreach (Universidad.EClases c1 in p1.clasesDelDia)
            {
                if (c1 == e1)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// comparo un profesor con un dato de ti po eclases
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="e1"></param>
        /// <returns></returns> bool
        public static bool operator !=(Profesor p1, Universidad.EClases e1)
        {
            return (!(p1 == e1));
        }
        /// <summary>
        /// Genero un numero random y con eso selecciono un dato de tipo eclases al azar
        /// </summary>
        private void randomClases()
        {
            int cont = 0;
            int guardar;
            while (cont < 2)
            {
                guardar = random.Next(0, 4);

                if (guardar == 1)
                {
                    this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                }
                else if (guardar == 2)
                {
                    this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                }
                else if (guardar == 3)
                {
                    this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                }
                else
                {
                    this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                }
                cont++;
            }
        }
    }
}
