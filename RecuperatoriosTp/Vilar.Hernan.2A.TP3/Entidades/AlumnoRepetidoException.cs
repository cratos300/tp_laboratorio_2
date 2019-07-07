using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class AlumnoRepetidoException:Exception
    {
        /// <summary>
        /// exception que se lanzara cuando hay alumnos repetidos
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno Repetido")
        {

        }
    }
}
