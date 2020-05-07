using System;
using System.Collections.Generic;
using TKZ.Shared.Model;
using TKZ.Shared;

namespace TKZ.Shared
{
    public partial class Grid
    {
        private static Grid CurrentGrid { get; set; } //Singleton needed
        
        public string Name { get; set; }
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
        public Dictionary<int, ResultCalc> ResCalc_K1 { get; set; }
        public Dictionary<int, ResultCalc> ResCalc_K11 { get; set; }
        public Dictionary<int, ResultCalc> ResCalc_K2 { get; set; }
        public Dictionary<int, ResultCalc> ResCalc_K3 { get; set; }

        //ctor
        public Grid()
        {
            this.Buses = new Dictionary<int, Bus>();
            this.Branches = new Dictionary<int, Branch>();
            this.Mutuals = new Dictionary<int, Mutual>();
            this.Equipment = new Dictionary<int, Equip>();

            //Test case. Erase on Realese.
            createTestGrid();
        }
    }
}