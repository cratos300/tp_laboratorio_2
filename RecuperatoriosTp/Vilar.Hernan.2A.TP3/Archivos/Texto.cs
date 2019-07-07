using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesAbstractas
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guardo los datos en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> retorno boleano
        public bool Guardar(string archivo, string datos)
        {
            bool bandera = false;
            bool retorno = false;
            StreamWriter sw = null;
            try
            {
               sw = new StreamWriter(archivo);
                sw.WriteLine(datos);
                retorno = true;
                bandera = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                if(bandera == true)
                {
                    sw.Close();
                }
            }
            return retorno;

        }

        /// <summary>
        /// Traigo los datos de un archivo de texto a memoria
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> retorno booleano
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            bool bandera = false;
            bool retorno = false;
            StreamReader sr = null;
            try
            {
                sr  = new StreamReader(archivo);
                datos = sr.ReadLine();
                bandera = true;
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if(bandera == true)
                {
                    sr.Close();
                }
            }
            return retorno;

        }
    }
}
