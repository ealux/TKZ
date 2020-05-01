using System.Collections.Generic;
using TKZ.Shared.Model;

namespace TKZ.Shared
{
    /// <summary>
    /// Stores the results of calculation short circuit current
    /// </summary>
    public class ResultCalc
    {
        public Dictionary<int,ResBus> Buses { get; set; }
        public Dictionary<int,ResBranch> Branches { get; set; }
        public ResultCalc(Grid grid)
        {
            Buses = new Dictionary<int,ResBus>();            
            Branches = new Dictionary<int, ResBranch>();

            foreach (Bus elem in grid.Buses.Values)       this.Buses.Add(elem.Id,new ResBus(elem.Id));
            foreach (Branch elem in grid.Branches.Values) this.Branches.Add(elem.Id,new ResBranch(elem.Id));
        }
    }
}