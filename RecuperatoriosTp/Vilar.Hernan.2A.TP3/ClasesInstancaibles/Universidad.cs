using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();

        }
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        /// <summary>
        /// Muestro los datos de la univesidad que recibo por parametro luego se llamara este metodo en tostring
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns> retorna string
        private static string MostrarDatos(Universidad uni)
        {

            StringBuilder sb = new StringBuilder();

            //sb.AppendLine("Los profesores son :");
            //foreach (Profesor p1 in uni.profesores)
            //{
            //    sb.AppendLine(p1.ToString());
            //}
            //sb.AppendLine("----------------------------------------------------------");
            //sb.AppendLine("Jornada :");
            //foreach (Jornada j1 in uni.jornada)
            //{
            //    sb.AppendLine(j1.ToString());
            //}
            //sb.AppendLine("----------------------------------------------------------");
            //sb.AppendLine("Los Alumnos son :");
            //foreach (Alumno a1 in uni.alumnos)
            //{
            //    sb.AppendLine(a1.ToString());
            //}
            foreach (Jornada item in uni.jornada)
            {
                sb.AppendFormat(item.ToString());
                sb.AppendLine("\n < ------------------------------------------------------------------- >");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Comparo una universidad con un alumno
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="a1"></param>
        /// <returns></returns> retorno un booleano
        public static bool operator ==(Universidad u1, Alumno a1)
        {
            bool retorno = false;
            foreach (Alumno a3 in u1.alumnos)
            {
                if (a3 == a1)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Comparo una universidad con un alumno
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="a1"></param>
        /// <returns></returns> retorno un booleano
        public static bool operator !=(Universidad u1, Alumno a1)
        {
            return !(u1 == a1);
        }
        /// <summary>
        /// comparo una universidad con un profesor
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="p1"></param>
        /// <returns></returns> retorno un booleano
        public static bool operator ==(Universidad u1, Profesor p1)
        {
            bool retorno = false;

            foreach (Profesor p3 in u1.Instructores)
            {
                if (p1 == p3)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// comparo una universidad con un profesor
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="p1"></param>
        /// <returns></returns> retorno un booleano
        public static bool operator !=(Universidad u1, Profesor p1)
        {
            return (!(u1 == p1));
        }
        /// <summary>
        /// "hago publico el metodo mostrar asi lo puedo llamar desde clases que no son protected"
        /// </summary>
        /// <returns></returns> retorno string
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        /// <summary>
        /// agrego un alumno a una universidad.alumnos si es que el mismo no esta.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>retorno universidad
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }
        /// <summary>
        /// sumo unprofesor a una universidad si el mismo no esta
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns> retorno universidad
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }
            else
            {
                throw new Exception("Ese profe ya esta");
            }
            return g;
        }
        /// <summary>
        /// verifico si ese profesor tiene la clase que comparo
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>retorno ese profesor
        public static Profesor operator ==(Universidad u, Universidad.EClases clase)
        {
            foreach (Profesor p1 in u.Instructores)
            {
                if (p1 == clase)
                {
                    return p1;
                }
            }
            throw new SinProfesorException();

        }
        /// <summary>
        /// retorno el primer profesor que no tenga es clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, Universidad.EClases clase)
        {
            foreach (Profesor p1 in u.Instructores)
            {
                if (p1 != clase)
                {
                    return p1;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Instancio un dato de tipo profesor, a este lo igualo a un dato de tipo universidad y eclases
        /// reutilizando codigo, agrego a la jornada el profesor y la clase, recorro con foreach
        /// si es que el alumno tiene esa clase lo agrego a la jornada y luego retorno la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns> retorno universidad
        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {

            Profesor p1;
            p1 = u == clase;

            Jornada j1 = new Jornada(clase, p1);
            foreach (Alumno a in u.alumnos)
            {
                if (a == clase)
                {
                    j1 = j1 + a;
                }
            }
            u.jornada.Add(j1);


            /*
            if(flag == 0)
            {
                throw new SinProfesorException();
            }
            */
            return u;

        }
        /// <summary>
        /// guardo en un archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns> retorno un booleano
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> data = new Xml<Universidad>();
            retorno = data.Guardar("Universidad", uni);
            return retorno;
        }
        /// <summary>
        /// traigo los datos de un xml
        /// </summary>
        /// <returns></returns> retorno una universidad
        public static Universidad Leer()
        {
            Universidad u1;
            Xml<Universidad> data = new Xml<Universidad>();
            data.Leer("Universidad", out u1);
            return u1;
        }


    }
}