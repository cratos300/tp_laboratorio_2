using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }

        }
        public string StringToDni
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Muestra los datos de la persona
        /// </summary>
        /// <returns></returns> retorna un string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //  sb.AppendFormat("Nombre Completo: {0}{1}\nDni: {2}\nNacionalidad: {3}\n", this.nombre, this.apellido, this.dni, this.nacionalidad);
            sb.AppendLine("NOMBRE COMPLETO: " + this.apellido + "," + this.nombre);
            sb.AppendLine("Nacionalidad:" + this.nacionalidad);
            return sb.ToString();
        }
        /// <summary>
        /// constructores
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// constructores
        /// </summary>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// constructores
        /// </summary>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            //this.nombre = nombre;
            //this.dni = dni;
            //this.apellido = aapeliido;
            //this.nacionalidad = nacionalidad;
            this.DNI = dni;
        }
        /// <summary>
        /// constructores
        /// </summary>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        /// <summary>
        /// Validara el dni, en el caso que pase algo, lanzara su respectiva excepcion
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        public int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
            {
                throw new NacionalidadInvalidaException("La nacionalidad no condice con el numero dni");
            }
            if (nacionalidad == ENacionalidad.Extranjero && dato < 90000000 || dato > 99999999)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no condice con el numero dni");
            }
            return dato;

        }
        /// <summary>
        /// Validara dni que recibe como string, para saber si se puede convertir y luego ir a la funcion de arriba
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        public int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int resultado;

            if (dato.Length > 8)
            {
                throw new DniInvalidoException("Error tiene menos de 1 caracter o mas de 8 el dni");
            }
            else
            {
                if (int.TryParse(dato, out resultado))
                {
                    resultado = ValidarDni(nacionalidad, resultado);
                    return resultado;
                }
                else
                {
                    throw new DniInvalidoException("Error no se pudo parsear a entero");
                }
            }

        }
        /// <summary>
        /// ValidarNombre validara que el formato de la cadena es valido, de lo contrario lanzara excepcion
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public string ValidarNombreApellido(string dato)
        {
            if (dato != "")
            {
                for (int i = 0; i < dato.Length; i++)
                {
                    if (char.IsNumber(dato[i]))
                    {
                        throw new DniInvalidoException("El formato de la cadena es invalido");
                    }
                }
            }
            return dato;
        }

    }
}
