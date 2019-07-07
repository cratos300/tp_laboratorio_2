using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
namespace Unitario
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// test que lanza ecepciones para verificar que anden correcto
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "1",
              EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
             Alumno.EEstadoCuenta.Deudor);
                Assert.Fail();
                
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
        [TestMethod]
        public void TestMethod2()
        {

            try
            {
                Alumno a2 = new Alumno(1, "Alberto", "Domingo", "90000000", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));

            }
        }
        /// <summary>
        /// El test verifica nulidad 
        /// </summary>
        [TestMethod]
       
        public void TestUniversidad()
        {

            try
            {
                Universidad u1 = new Universidad();
                u1.ToString();
                //Verifico que al llamar al metodo de la universidad no me salte una exception de que no instancie
                // las listas osea la nulidad.
                //Assert.IsNotNull(u1."nombre del atributo"); Tambien se puede hacer asi.

            }
            catch (Exception e)
            {
                Assert.Fail();

            }
        }
        [TestMethod]
        public void TestDniNoSePuedeParsear()
        {

            try
            {
                Alumno a1 = new Alumno(23, "hernan", "vilar", "23a", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
                //Verifico que al llamar al metodo de la universidad no me salte una exception de que no instancie
                // las listas
                Assert.Fail();

            }
            catch (DniInvalidoException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
