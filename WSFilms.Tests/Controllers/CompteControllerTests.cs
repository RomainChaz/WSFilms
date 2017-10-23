using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSFilms.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSFilms.Models.Entity;
using System.Web.Http.Results;
using System.Net;

namespace WSFilms.Controllers.Tests
{
    [TestClass]
    public class CompteControllerTests
    {
        public CompteController cc;
        public T_E_COMPTE_CPT toAdd;

        [TestInitialize]
        public void InitTest()
        {
            this.cc = new CompteController();
            this.toAdd = new T_E_COMPTE_CPT();
        }
        
        [TestMethod()]
        public void GetCompteTest()
        {
            InitTest();
            IQueryable<T_E_COMPTE_CPT> comptes = this.cc.GetCompte();
            Assert.AreEqual(comptes.Count(), 4);
            CleanTest();
        }

        [TestMethod()]
        public void GetTest1()
        {
            InitTest();
            OkNegotiatedContentResult<T_E_COMPTE_CPT> result = (OkNegotiatedContentResult<T_E_COMPTE_CPT>)this.cc.GetCompte(2);
            Assert.AreEqual(result.Content.CPT_ID, 2);
            CleanTest();
        }

        [TestMethod()]
        public void GetTest2()
        {
            InitTest();
            OkNegotiatedContentResult<T_E_COMPTE_CPT> result = (OkNegotiatedContentResult<T_E_COMPTE_CPT>)this.cc.GetCompte("paul.durand@gmail.com");
            Assert.AreEqual(result.Content.CPT_MEL, "paul.durand@gmail.com");
            CleanTest();
        }

        [TestMethod()]
        public void PutCompteTest()
        {
            IQueryable<T_E_COMPTE_CPT> comptes2 = this.cc.GetCompte();

            T_E_COMPTE_CPT toUpdate = comptes2.FirstOrDefault();

            Assert.IsNotNull(toUpdate);

            toUpdate.CPT_TELPORTABLE = "0606060606";
            toUpdate.CPT_PWD = "Luc4s?";

            var result = this.cc.PutCompte(1, toUpdate) as StatusCodeResult;

            Assert.AreEqual(result.StatusCode, HttpStatusCode.NoContent);

        }

        [TestMethod()]
        public void PostCompteTest()
        {            
            toAdd.CPT_CP = "69850";
            toAdd.CPT_LATITUDE = null;
            toAdd.CPT_LONGITUDE = null;
            toAdd.CPT_MEL = "romain.chazottier@gmail.com";
            toAdd.CPT_NOM = "Chazottier";
            toAdd.CPT_PRENOM = "Romain";
            toAdd.CPT_PAYS = "France";
            toAdd.CPT_PWD = "R0main#";
            toAdd.CPT_RUE = "209 Avenue Roger Salengro";
            toAdd.CPT_TELPORTABLE = "0707070707";
            toAdd.CPT_VILLE = "Villeurbanne";

            this.cc.PostCompte(toAdd);

            IQueryable<T_E_COMPTE_CPT> comptes3 = this.cc.GetCompte();

            Assert.AreEqual(comptes3.Count(), 5);

            this.cc.DeleteCompte(toAdd.CPT_ID);
        }

        [TestCleanup]
        public void CleanTest()
        {
        }
    }
}