using System;
using System.Collections.Generic;
using TKZ.Shared.Model;

namespace TKZ.Shared
{
    public partial class Grid
    {
        private Bus BusGround = new Bus(0, "Земля", true);
        public double ArcR { get; set; }
        public double ArcX { get; set; }
        public Dictionary<int, Bus> Buses { get; set; }
        public Dictionary<int, Branch> Branches { get; set; }
        public Dictionary<int, Mutual> Mutuals { get; set; }

        /// <summary>
        /// Stores calculation results.
        /// Index - A BusID in which a short circuit.
        /// </summary>
        /// <value></value>
        public Dictionary<int, ResultCalc> ResCalc { get; set; }

        //ctor
        public Grid()
        {
            Buses = new Dictionary<int, Bus>();
            Branches = new Dictionary<int, Branch>();
            Mutuals = new Dictionary<int, Mutual>();

            //Must have            
            this.Buses.Add(this.BusGround.Id, this.BusGround);

            //Test case. Erase on Realese.
            createTestGrid();
        }
    }
}