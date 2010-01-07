﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestfulieClient.resources;
using RestfuliClientTests.helpers;

namespace RestfuliClientTests
{
    /// <summary>
    /// Summary description for EntryPointTests
    /// </summary>
    [TestClass]
    public class EntryPointTests
    {
        public EntryPointTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ShouldBePossibleToGetAResourceRepresentationByTheEntryFluentInteface()
        {
            dynamic order = Restfulie.At("http:\\localhost:3000\\order\\1.xml",GetEntryPointServiceForTests()).Get();
            Assert.IsNotNull(order);
            Assert.IsNotNull(order.date, "the attribute date is no expected");
            Assert.IsNotNull(order.total, "the attribute total is no expected");        
        }
        
        [TestMethod]
        public void ShouldBePossibleDefineConfigurationOfEntryPointService()
        {
            Restfulie entryPoint = Restfulie.At("uri", GetEntryPointServiceForTests());
            Assert.IsNotNull(entryPoint.EntryPointService);
        }

        [TestMethod]
        public void ShouldHasAnInstanceOfDefaultEntryPointServiceDefinedWithoutSetAConfiguration()
        {
            Restfulie entryPoint = Restfulie.At("uri");
            Assert.IsNotNull(entryPoint.EntryPointService);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldBeThrowAnErrorIfTheInvokeGetMethodWithoutUriDefined()
        {
            Restfulie entryPoint = Restfulie.At("", GetEntryPointServiceForTests());
            dynamic order = entryPoint.Get();
        }

        [TestMethod]
        public void ShoudBePossibleToGetAWebReponse()
        {
            dynamic order = Restfulie.At("http:\\localhost:3000\\order\\1.xml",GetEntryPointServiceForTests()).Get();
            Assert.IsNotNull(order.WebResponse);           
        }

        [TestMethod]
        public void ShouldBePossibleToGetTheResponseStatusCode()
        { 
            dynamic order = Restfulie.At("http:\\localhost:3000\\order\\1.xml",GetEntryPointServiceForTests()).Get();
            Assert.IsNotNull(order.WebResponse.StatusCode);           
        }

        private EntryPointService GetEntryPointServiceForTests()
        {
            return new EntryPointService() { RemoteResourceService = RemoteResourceFactory.GetRemoteResource() };
        }
    }
}