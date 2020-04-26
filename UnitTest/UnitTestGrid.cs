using Microsoft.VisualStudio.TestTools.UnitTesting;
using TKZ.Shared.Model;
using TKZ.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TKZ.Test
{
    [TestClass]
    public class UnitTestGrid
    {
        //[SetUp]
        public void Setup()
        {
            
        }
        

        [TestMethod]
        public void TestMethod_CheckConnectivityGrid_true()
        {
            Grid grid = TestGrid.smalTestGrid();
            bool res = grid.CheckConnectivityGrid();
            bool Expected = true;
            Assert.AreEqual(Expected, res);
        }

        [TestMethod]
        public void TestMethod_CheckConnectivityGrid_false()
        {
            Grid grid = TestGrid.smalTestGrid2();
            bool res = grid.CheckConnectivityGrid();
            bool Expected = false;
            Assert.AreEqual(Expected, res);
        }

        [TestMethod]
        public void TestMethod_CheckContainsMissingBusId_false()
        {
            Grid grid = TestGrid.smalTestGrid();
            bool res = grid.CheckContainsMissingBusId();
            bool Expected = false;
            Assert.AreEqual(Expected, res);
        }

        [TestMethod]
        public void TestMethod_CheckContainsMissingBusId_true()
        {
            Grid grid = TestGrid.smalTestGrid3();
            bool res = grid.CheckContainsMissingBusId();
            bool Expected = true;
            Assert.AreEqual(Expected, res);
        }
    }
}
