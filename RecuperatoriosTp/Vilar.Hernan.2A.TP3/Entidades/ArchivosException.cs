using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public class ArchivosException:Exception
    {
        /// <summary>
        /// exception que se lanza cuando  hay archivo que no se pudo abrir
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException):base("No se pudo abrir el archivo",innerException)
        {

        }

    }
}
