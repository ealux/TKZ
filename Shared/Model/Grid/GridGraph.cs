using System.Collections.Generic;
using System.Linq;
using TKZ.Shared.Model;

namespace TKZ.Shared
{
    public partial class Grid
    {
        /// <summary>
        /// Finds branches from a given bus.
        /// </summary>
        /// <param name="BusId"> Id start Bus.</param>
        /// <param name="numBelt"> Count belt for find branch.</param>
        /// <returns>Branch Id</returns>
        public List<int> FindBranchBelt(int BusId, int numBelt)
        {
            if (this.Branches.Count() < 1 || this.Buses.Count() < 2) return new List<int>();
            if (numBelt < 1) numBelt = 1;

            Dictionary<int, bool> dicBranches = new Dictionary<int, bool>();
            Dictionary<int, bool> dicBuses = new Dictionary<int, bool>();

            foreach (Branch b in this.Branches.Values.ToList()) dicBranches.Add(b.Id, false);
            foreach (Bus b in this.Buses.Values.ToList()) dicBuses.Add(b.Id, false);

            RecursiveFindBeltBranch(dicBranches, dicBuses, BusId, numBelt);

            List<int> res = new List<int>();
            foreach (int i in dicBranches.Keys) if (dicBranches[i] == true) res.Add(i);
            return res;
        }

        private void RecursiveFindBeltBranch(Dictionary<int, bool> dicBranches, Dictionary<int, bool> dicBuses, int BusId, int Belt)
        {
            dicBuses[BusId] = true;
            if (Belt < 1 || BusId == 0) return; //must not worked, if bus is ground

            List<int> l = FindAllBranchOnBusID(BusId);
            for (int ind = 0; ind < l.Count; ind++)
            {
                int cur = l[ind];
                dicBranches[cur] = true;
                if (this.Branches[cur].StartBusId == BusId)
                {
                    if (dicBuses[Branches[cur].FinalBusId] == false) RecursiveFindBeltBranch(dicBranches, dicBuses, Branches[cur].FinalBusId, Belt - 1);
                    continue;
                }
                if (this.Branches[cur].FinalBusId == BusId)
                {
                    if (dicBuses[Branches[cur].StartBusId] == false) RecursiveFindBeltBranch(dicBranches, dicBuses, Branches[cur].StartBusId, Belt - 1);
                    continue;
                }
            }
        }

        /// <summary>
        /// Find all branch connectivity given bus.
        /// </summary>
        /// <param name="BusId"> Start Bus Id for find branch.</param>
        /// <returns>Branch ID</returns>
        public List<int> FindAllBranchOnBusID(int BusId)
        {
            List<int> res = new List<int>();
            foreach (Branch b in this.Branches.Values)
            {
                if (b.StartBusId == BusId | b.FinalBusId == BusId) res.Add(b.Id);
            }
            return res;
        }

        /// <summary>
        /// Find all neighbors bus.
        /// </summary>
        /// <param name="BusId">The bus for which to look for neighbors</param>
        /// <returns>Bus Id</returns>
        public List<int> FindNeighbourBus(int BusId)
        {
            List<int> res = new List<int>();
            List<int> br = FindAllBranchOnBusID(BusId);
            for (int ind = 0; ind < br.Count(); ind++)
            {
                if (this.Branches[br[ind]].StartBusId != BusId | this.Branches[br[ind]].FinalBusId != BusId) res.Add(BusId);
            }
            return res;
        }

        /// <summary>
        /// Check grid connectivity 
        /// </summary>
        /// <returns>/// true  - 1 island; false - many island.</returns>
        public bool CheckConnectivityGrid()
        {
            if (this.Buses.Count() < 2) return true;
            if (this.Branches.Count() < 1) return false;

            Dictionary<int, int> dicBuses = FindIslandGrid();
            int numIsland = dicBuses.Values.ToArray().Distinct().ToArray().Count();

            if (numIsland == 1) return true; 
            else return false;
        }

        /// <summary>
        /// Find all island grid.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, int> FindIslandGrid()
        {
            if (this.Buses.Count() < 2 || this.Branches.Count() < 1) return new Dictionary<int, int>();

            Dictionary<int, int> dicBuses = new Dictionary<int, int>();
            int ind = 0;
            foreach (int busId in this.Buses.Keys.ToList()) dicBuses.Add(busId, ind++);

            bool FlagChange = true;

            int[] keys = this.Branches.Keys.ToArray();
            while (FlagChange)
            {
                FlagChange = false;
                for (ind = 0; ind < keys.Count(); ind++)
                {
                    int s = this.Branches[keys[ind]].StartBusId;
                    int f = this.Branches[keys[ind]].FinalBusId;
                    if (dicBuses[s] < dicBuses[f]) { dicBuses[f] = dicBuses[s]; FlagChange = true; continue; }
                    if (dicBuses[f] < dicBuses[s]) { dicBuses[s] = dicBuses[f]; FlagChange = true; continue; }
                }
            }
            return dicBuses;
        }

        /// <summary>
        /// Check contains bus Id all Branches in Buses.
        /// </summary>
        /// <returns>true - there is a missing bus; flase - all rigth </returns>
        public bool CheckContainsMissingBusId()
        {
            if (FindMissingBusId().Count() > 0) return true; 
            else return false;
        }

        /// <summary>
        /// Find in Branches to all missing bus Id.
        /// </summary>
        /// <returns>List missing bus Id</returns>
        public List<int> FindMissingBusId()
        {
            List<int> res = new List<int>();
            int[] keys = this.Branches.Keys.ToArray();
            for (int ind = 0; ind < keys.Length; ind++)
            {
                if (!this.Buses.ContainsKey(this.Branches[keys[ind]].StartBusId)) res.Add(this.Branches[keys[ind]].StartBusId);
                if (!this.Buses.ContainsKey(this.Branches[keys[ind]].FinalBusId)) res.Add(this.Branches[keys[ind]].FinalBusId);
            }
            return res.Distinct().ToList();
        }
    }
}