using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public  class NacionalidadInvalidaException:Exception
    {/// <summary>
    /// excepciones que se lanzaran cuando la nacionalidad es invalidad
    /// </summary>
        public NacionalidadInvalidaException():base()
        {

        }
        public NacionalidadInvalidaException(string data):base(data)
        {

        }
    }
}
