using System;
using System.Collections.Generic;
using TKZ.Shared.Model;
using TKZ.Shared;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TKZ.Shared
{
    public partial class Grid
    {
        private static Grid CurrentGrid { get; set; } //Singleton needed
        public static List<Grid> Networks = new List<Grid>() { createTestGrid() };
        
        public string Name { get; set; }
        public double ArcR { get; set; }
        public double ArcX { get; set; }

        public Dictionary<int, Bus> Buses { get; set; } = new Dictionary<int, Bus>();
        public Dictionary<int, Equip> Equipment { get; set; } = new Dictionary<int, Equip>();
        public Dictionary<int, Branch> Branches { get; set; } = new Dictionary<int, Branch>();
        public Dictionary<int, Mutual> Mutuals { get; set; } = new Dictionary<int, Mutual>();

        /// <summary>
        /// Stores calculation results.
        /// Index - A BusID in which a short circuit.
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public Dictionary<int, ResultCalc> ResCalc_K1 { get; set; } = new Dictionary<int, ResultCalc>();
        [JsonIgnore]
        public Dictionary<int, ResultCalc> ResCalc_K11 { get; set; } = new Dictionary<int, ResultCalc>();
        [JsonIgnore]
        public Dictionary<int, ResultCalc> ResCalc_K2 { get; set; } = new Dictionary<int, ResultCalc>();
        [JsonIgnore]
        public Dictionary<int, ResultCalc> ResCalc_K3 { get; set; } = new Dictionary<int, ResultCalc>();

        //ctor
        public Grid() { }

        //Get Current grid
        public static async Task<Grid> GetInstance()
        {
            if (CurrentGrid == null) CurrentGrid = new Grid();
            return await Task.Run(() => { return CurrentGrid; });
        }

        //Set Current grid
        public static void SetInstance(Grid grid)
        {
            if (grid == null)
            {
                CurrentGrid = new Grid();
                return;
            }
            CurrentGrid = grid;
            if (!Networks.Contains(grid)) Networks.Add(grid);
        }
    }
}