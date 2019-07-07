using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Son los metodos de las interfaces que luego usare cuando implemente dicha interface.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> retorno booleano
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}