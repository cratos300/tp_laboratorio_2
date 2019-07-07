using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class DniInvalidoException:Exception
    {
        private string mensajeBase;
        /// <summary>
        /// excepciones que se lanzaran cuando hay error de formato, etc de dni
        /// </summary>
        public DniInvalidoException():base()
        {

        }
        public DniInvalidoException(Exception e):base()
        {

        }
        public DniInvalidoException(string message):base(message)
        {
            this.mensajeBase = message;
        }
        public DniInvalidoException(string message, Exception e)
        {
            this.mensajeBase = message;
        }
    }
}
