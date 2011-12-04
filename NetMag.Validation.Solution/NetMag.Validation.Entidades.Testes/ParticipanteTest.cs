using NetMag.Validation.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace NetMag.Validation.Entidades.Testes
{    
    /// <summary>
    ///This is a test class for ParticipanteTest and is intended
    ///to contain all ParticipanteTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParticipanteTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Participante Constructor
        ///</summary>
        [TestMethod()]
        public void ParticipanteConstructorTest()
        {
            string nome = "LD";
            string email = "abc@@com..";
            DateTime dataNascimento = Convert.ToDateTime("21/03/2000"); 
            DateTime dataInscricao = DateTime.Now;
            string meioComunicacao = "Revista .Net Magazine"; 
            string voucher = string.Empty; 
            string comentarios = "Utilizando o Validation Application Block.";

            Participante participante = new Participante(
                nome, email, dataNascimento, dataInscricao, 
                meioComunicacao, voucher, comentarios);

            Validator<Participante> validador = 
                ValidationFactory.CreateValidator<Participante>();
            ValidationResults resultados = validador.Validate(participante);

            if (!resultados.IsValid)
            {
                foreach (ValidationResult result in resultados)
                {
                    // Código para tratamento do erro aqui.
                }
            }

            Assert.AreNotEqual(resultados.Count, 0);
        }
    }
}
