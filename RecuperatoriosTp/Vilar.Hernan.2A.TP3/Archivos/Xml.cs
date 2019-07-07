using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    public class Xml<T> : IArchivo<T> where T : new()
    {
        /// <summary>
        /// Guardo el un archivo xml los datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> retorno boleano
        public bool Guardar(string archivo, T datos)
        {
            bool bandera = false;
            bool retorno = false;
            StreamWriter sw = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                sw = new StreamWriter(archivo);
                xml.Serialize(sw, datos);
                retorno = true;
                bandera = true;

            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                if (bandera == true)
                {
                    sw.Close();
                }
            }
            return retorno;
        }
        /// <summary>
        /// Traigo de un archivo xml los datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> retorno boleano
        public bool Leer(string archivo, out T datos)
        {
            bool bandera = false;
            bool retorno = false;
            StreamReader sw = null;
            try
            {
                T data = new T();
                XmlSerializer xml = new XmlSerializer(typeof(T));
                //Necesito un objecto que sepa escribir o leer.
                sw = new StreamReader(archivo);
                data = (T)xml.Deserialize(sw);
                datos = data;
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
                    sw.Close();
                }
            }
            return retorno;
        }
    }
}
