using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class SinProfesorException:Exception
    {
        /// <summary>
        /// Se genera una excepcion para luego utilizarla
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase.")
        {

        }
    }
}
