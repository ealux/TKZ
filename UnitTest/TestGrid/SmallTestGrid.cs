using Microsoft.VisualStudio.TestTools.UnitTesting;
using TKZ.Shared.Model;
using TKZ.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TKZ.Test
{
    public static class TestGrid
    {
        /// <summary>
        /// Grid is connectiv on two buses.
        /// </summary>
        /// <returns></returns>
        static public Grid smalTestGrid()
        {
            Grid grid = new Grid();

            grid.Buses = new Dictionary<int, Bus>();
            grid.Branches = new Dictionary<int, Branch>();
            grid.Mutuals = new Dictionary<int, Mutual>();

            Bus gr = new Bus(0, "Земля", true);           
            Bus b1 = new Bus(100, "1");
            Bus b2 = new Bus(100, "2");            

            grid.Buses.Add(gr.Id, gr);
            grid.Buses.Add(b1.Id, b1);
            grid.Buses.Add(b2.Id, b2);

            Branch br1 = new Branch(b1.Id, b2.Id, "1-2",   1, 2, 3, 4, 0, 0, 0, false, false, 0, 0);
            Branch br2 = new Branch(gr.Id, b2.Id, "Зем-2", 1, 2, 3, 4, 0, 0, 0, true, false, 0, 0);

            grid.Branches.Add(br1.Id, br1);
            grid.Branches.Add(br2.Id, br2);                        

            return grid;
        }

        /// <summary>
        /// Grid is not connectiv on two buses.
        /// </summary>
        /// <returns></returns>
        static public Grid smalTestGrid2()
        {
            Grid grid = new Grid();

            grid.Buses = new Dictionary<int, Bus>();
            grid.Branches = new Dictionary<int, Branch>();
            grid.Mutuals = new Dictionary<int, Mutual>();

            Bus gr = new Bus(0, "Земля", true);           
            Bus b1 = new Bus(100, "1");
            Bus b2 = new Bus(100, "2");            

            grid.Buses.Add(gr.Id, gr);
            grid.Buses.Add(b1.Id, b1);
            grid.Buses.Add(b2.Id, b2);

            //Branch br1 = new Branch(b1.Id, b2.Id, "1-2", 1, 2, 3, 4, 0, 0, 0, false, false, 0, 0);
            Branch br2 = new Branch(gr.Id, b2.Id, "Зем-2", 1, 2, 3, 4, 0, 0, 0, true, false, 0, 0);

            //grid.Branches.Add(br1.Id, br1);
            grid.Branches.Add(br2.Id, br2);                        

            return grid;
        }

        /// <summary>
        /// Grid with out one bus.
        /// </summary>
        /// <returns></returns>
        static public Grid smalTestGrid3()
        {
            Grid grid = new Grid();

            grid.Buses = new Dictionary<int, Bus>();
            grid.Branches = new Dictionary<int, Branch>();
            grid.Mutuals = new Dictionary<int, Mutual>();

            Bus gr = new Bus(0, "Земля", true);           
            Bus b1 = new Bus(100, "1");
            Bus b2 = new Bus(100, "2");            

            grid.Buses.Add(gr.Id, gr);
            grid.Buses.Add(b1.Id, b1);
            //grid.Buses.Add(b2.Id, b2);

            Branch br1 = new Branch(b1.Id, b2.Id, "1-2", 1, 2, 3, 4, 0, 0, 0, false, false, 0, 0);
            Branch br2 = new Branch(gr.Id, b2.Id, "Зем-2", 1, 2, 3, 4, 0, 0, 0, true, false, 0, 0);

            grid.Branches.Add(br1.Id, br1);
            grid.Branches.Add(br2.Id, br2);                        

            return grid;
        }
        
        /// <summary>
        /// Grid contains one ground transformer (3) and generator between two buses.
        /// </summary>
        /// <returns></returns>
        static public Grid smalTestGrid4()
        {
            Grid grid = new Grid();

            grid.Buses = new Dictionary<int, Bus>();
            grid.Branches = new Dictionary<int, Branch>();
            grid.Mutuals = new Dictionary<int, Mutual>();

            Bus gr = new Bus(0, "Земля", true);           
            Bus b1 = new Bus(100, "1");
            Bus b2 = new Bus(100, "2");            

            grid.Buses.Add(gr.Id, gr);
            grid.Buses.Add(b1.Id, b1);
            grid.Buses.Add(b2.Id, b2);

            Branch br1 = new Branch(b1.Id, b2.Id, "1-2", 1, 2, 3, 4, 0, 0, 0, false, false, 0, 0);
            Branch br2 = new Branch(gr.Id, b2.Id, "Зем-2", 1, 2, 3, 4, 0, 0, 0, true, false, 0, 0);

            grid.Branches.Add(br1.Id, br1);
            grid.Branches.Add(br2.Id, br2);                        

            Branch br3 = new Branch(b1.Id , 0, "Транс-Зем", 1, 2, 3, 4, 5, 6, 7, false, false, 0, 0);
            Branch br4 = new Branch(b1.Id, b2.Id, "1-Ген-2", 1, 2, 3, 4, 0, 0, 0, true, false, 1, 1);

            grid.Branches.Add(br3.Id, br3);
            grid.Branches.Add(br4.Id, br4);                        

            return grid;
        }
    }
}