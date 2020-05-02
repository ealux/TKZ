using System;
using System.Collections.Generic;
using TKZ.Shared.Model;
using TKZ.Shared;

namespace TKZ.Shared
{
    public partial class Grid
    {
        private static Grid CurrentGrid { get; set; } //Singleton needed

        //private Bus BusGround = new Bus(0, "Земля", true);
        public double ArcR { get; set; }
        public double ArcX { get; set; }

        public Dictionary<int, Bus> Buses { get; set; }
        public Dictionary<int, Equip> Equipment { get; set; }
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
            this.Buses = new Dictionary<int, Bus>();
            this.Branches = new Dictionary<int, Branch>();
            this.Mutuals = new Dictionary<int, Mutual>();
            this.Equipment = new Dictionary<int, Equip>();
            
            //Must have            
            //this.Buses.Add(BusGround.Id, BusGround);

            //Test case. Erase on Realese.
            createTestGrid();
        }
    }
}