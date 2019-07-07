using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public class Jornada
    {
        Profesor instructor;
        Universidad.EClases clase;
        List<Alumno> alumnos;

        
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }



        public Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.instructor = instructor;
            this.clase = clase;
        }
        /// <summary>
        /// Comparo una jornada con un alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns> retorno booleano
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno a1 in j.alumnos)
            {
                if (a1 == a)
                {
                    retorno = true;
                }
            }
            //if (j.Alumnos.Contains(a))
            //{
            //    retorno = true;
            //}
            return retorno;
        }
        /// <summary>
        /// Comparo una jornada con un alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns> retorno booleano
        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }
        /// <summary>
        ///  sumo una jornada con un alumno
        /// </summary>
        /// <param name="j1"></param>
        /// <param name="a"></param>
        /// <returns></returns> retorno una jornada
        public static Jornada operator +(Jornada j1, Alumno a)
        {
            if (j1 != a)
            {
                j1.alumnos.Add(a);
            }
            return j1;
        }
        /// <summary>
        ///  retorno los datos de la jornada.
        /// </summary>
        /// <returns></returns> string 
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
       
            sb.AppendFormat("Instructor{0}Jornada de {1}", this.instructor.ToString(), this.clase.ToString());
            sb.AppendLine("\nAlumnos");
            foreach (Alumno a1 in this.alumnos)
            {
                // sb.AppendLine(a1.ToString());
                sb.Append(a1);
            }
            return sb.ToString();
        }
        /// <summary>
        ///  guardo en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns> devuelvo booleano si se pudo o no.
        public static bool Guardar(Jornada jornada)
        {
            bool retorno;
            Texto nt = new Texto();
            retorno = nt.Guardar("Dato.txt", jornada.ToString());
            return retorno;
        }
        /// <summary>
        /// tomo los datos de un archivo de texto
        /// </summary>
        /// <returns></returns> devuelvo un string
        public static string Leer()
        {
            string data = "";
            Texto nt = new Texto();
            nt.Leer("Dato.txt", out data);
            return data;
        }




    }
}
