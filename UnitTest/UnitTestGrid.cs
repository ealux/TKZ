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
        [TestMethod]
        public void TestMethod_FindBranchTransformerGround_FindSucess()
        {
            Grid grid = TestGrid.smalTestGrid4();
            Branch br1 = grid.Branches.Values.ToArray()[2];
            int res = grid.FindBranchTransformerGround()[0];
            int Expected = br1.Id;
            Assert.AreEqual(Expected, res, "Не найдена ветвь: " + br1.Name );
        }
        [TestMethod]
        public void TestMethod_FindBranchTransformerGround_FindFail()
        {
            Grid grid = TestGrid.smalTestGrid();
            List<int> res = grid.FindBranchTransformerGround();
            int Expected = 0;
            Assert.AreEqual(Expected, res.Count());
        }
        [TestMethod]
        public void TestMethod_FindGeneratorBetweenBuses_FindSucess()
        {
            Grid grid = TestGrid.smalTestGrid4();
            Branch br1 = grid.Branches.Values.ToArray()[3];
            int res = grid.FindGeneratorBetweenBuses()[0];
            int Expected = br1.Id;
            Assert.AreEqual(Expected, res, "Не найдена ветвь: " + br1.Name );
        }
        [TestMethod]
        public void TestMethod_FindGeneratorBetweenBuses_FindFail()
        {
            Grid grid = TestGrid.smalTestGrid();
            List<int> res = grid.FindGeneratorBetweenBuses();
            int Expected = 0;
            Assert.AreEqual(Expected, res.Count());
        }
        
    }
}
