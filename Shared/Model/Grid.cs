using System;
using System.Linq;
using System.Collections.Generic;
using TKZ.Shared.Model;
using System.Globalization;

namespace TKZ.Shared
{    
    public class Grid
    {
        public double ArcR {get; set;}
        public double ArcX {get; set;}
        public Dictionary<int, Bus> Buses { get; set; }
        public Dictionary<int, Branch> Branches { get; set; }
        public Dictionary<int, Mutual> Mutuals { get; set; }

        public Grid()
        {
            Buses = new Dictionary<int, Bus>();
            Branches = new Dictionary<int, Branch>();
            Mutuals = new Dictionary<int, Mutual>();

            //Must have
            Bus gr = new Bus(0, "Земля", true);
            this.Buses.Add(gr.Id, gr);


            //Test case. Erase on Realese.
            Bus b1 = new Bus(100,"1");
            Bus b2 = new Bus(100,"2");
            Bus b3 = new Bus(100,"3");
            Bus b4 = new Bus(100,"4");
            Bus b5 = new Bus(100,"5");
            Bus b6 = new Bus(100,"6");
            Bus b7 = new Bus(100,"7");
            Bus b8 = new Bus(100,"8");
            Bus b9 = new Bus(100,"9");
            Bus b10 = new Bus(100,"10");
            
            this.Buses.Add(b1.Id,b1);
            this.Buses.Add(b2.Id,b2);
            this.Buses.Add(b3.Id,b3);
            this.Buses.Add(b4.Id,b4);
            this.Buses.Add(b5.Id,b5);
            this.Buses.Add(b6.Id,b6);
            this.Buses.Add(b7.Id,b7);
            this.Buses.Add(b8.Id,b8);
            this.Buses.Add(b9.Id,b9);
            this.Buses.Add(b10.Id,b10);

            Branch br1 = new Branch(b1.Id,b2.Id,"1-2",1,2,3,4,5,6,7,false,false,1,1);
            Branch br2 = new Branch(b3.Id,b1.Id,"3-1",1,2,3,4,5,6,7,false,false,1,1);
            Branch br3 = new Branch(b1.Id,b4.Id,"1-4",1,2,3,4,5,6,7,false,false,1,1);
            Branch br4 = new Branch(b2.Id,b5.Id,"2-5",1,2,3,4,5,6,7,false,false,1,1);
            Branch br5 = new Branch(b3.Id,b6.Id,"3-6",1,2,3,4,5,6,7,false,false,1,1);
            Branch br6 = new Branch(b3.Id,b7.Id,"3-7",1,2,3,4,5,6,7,false,false,1,1);
            Branch br7 = new Branch(b4.Id,b8.Id,"4-8",1,2,3,4,5,6,7,false,false,1,1);
            Branch br8 = new Branch(b5.Id,b9.Id,"5-9",1,2,3,4,5,6,7,false,false,1,1);
            Branch br9 = new Branch(b6.Id,b10.Id,"6-10",1,2,3,4,5,6,7,false,false,1,1);
            Branch br10 = new Branch(b7.Id,b8.Id,"7-8",1,2,3,4,5,6,7,false,false,1,1);
            Branch br11 = new Branch(b2.Id,gr.Id,"2-Зем",1,2,3,4,5,6,7,false,true,1,1);
            Branch br12 = new Branch(gr.Id,b8.Id,"Зем-8",1,2,3,4,5,6,7,true,false,1,1);

            this.Branches.Add(br1.Id,br1);
            this.Branches.Add(br2.Id,br2);
            this.Branches.Add(br3.Id,br3);
            this.Branches.Add(br4.Id,br4);
            this.Branches.Add(br5.Id,br5);
            this.Branches.Add(br6.Id,br6);
            this.Branches.Add(br7.Id,br7);
            this.Branches.Add(br8.Id,br8);
            this.Branches.Add(br9.Id,br9);
            this.Branches.Add(br10.Id,br10);
            this.Branches.Add(br11.Id,br11);
            this.Branches.Add(br12.Id,br12);

            Console.WriteLine(br4.Id);

            Mutual m1 = new Mutual(br1.Id,br2.Id,1,2);
            Mutual m2 = new Mutual(br3.Id,br4.Id,13,2);

            this.Mutuals.Add(m1.Id,m1);
            this.Mutuals.Add(m2.Id,m2);
        }      
        /// <summary>
        /// Finds branches from a given bus.
        /// </summary>
        /// <param name="BusId"> Id start Bus.</param>
        /// <param name="numBelt"> Count belt for find branch.</param>
        /// <returns></returns>
        public List<int> FindBranchBelt(int BusId, int numBelt)
        {
            if (this.Branches.Count() < 1) return new List<int>();
            if (this.Buses.Count()    < 2) return new List<int>();
            if (numBelt <1) numBelt = 1;           

            Dictionary<int,bool> dicBranches = new Dictionary<int, bool>();
            Dictionary<int,bool> dicBuses = new Dictionary<int, bool>();
            foreach (Branch b in this.Branches.Values.ToList()) dicBranches.Add(b.Id,false);
            foreach (Bus b in this.Buses.Values.ToList())       dicBuses.Add(b.Id,false);

            RecursiveFindBeltBranch(dicBranches,dicBuses,BusId,numBelt);
            
            List<int> res = new List<int>();                        
            foreach (int i in dicBranches.Keys) if (dicBranches[i] == true) res.Add(i);            
            return res;
        }   
        private void RecursiveFindBeltBranch(Dictionary<int,bool> dicBranches,Dictionary<int,bool> dicBuses,int BusId,int Belt)
        {
            dicBuses[BusId] = true;
            if (Belt < 1) return;
            if (BusId == 0) return; //must not worked, if bus ground

            int[] l = FindAllBranchOnBusID(BusId);
            for (int ind = 0; ind < l.Count(); ind++)
            {
                int cur = l[ind];
                dicBranches[cur] = true;
                if (this.Branches[cur].StartBusId  == BusId)
                {
                    if (dicBuses[Branches[cur].FinalBusId]==false) RecursiveFindBeltBranch (dicBranches, dicBuses,Branches[cur].FinalBusId,Belt - 1);
                    continue;
                }
                if (this.Branches[cur].FinalBusId == BusId) 
                {
                    if (dicBuses[Branches[cur].StartBusId]==false) RecursiveFindBeltBranch (dicBranches, dicBuses,Branches[cur].StartBusId, Belt - 1);
                    continue;
                }
            }
        }
        /// <summary>
        /// Find all branch connectivity given bus.
        /// </summary>
        /// <param name="BusId"> Start Bus Id for find branch.</param>
        /// <returns></returns>
        private int[] FindAllBranchOnBusID(int BusId)
        {            
            List<int> br = new List<int>();
            foreach (Branch b in this.Branches.Values )
            {
                if (b.StartBusId ==BusId ) br.Add(b.Id);
                if (b.FinalBusId ==BusId ) br.Add(b.Id);
            }
            int[] res = br.Distinct().ToArray();
            Array.Sort(res);
            return res;
        }

        /// <summary>
        /// Check connectivity grid. Return
        /// true  - 1 island;
        /// false - many island. 
        /// </summary>
        /// <returns></returns>
        public bool CheckConnectivityGrid()
        {            
            if (this.Buses.Count()    < 2) return true;
            if (this.Branches.Count() < 1) return false;
            Dictionary<int,int> dicBuses = FindIslandGrid();
            int numIsland = dicBuses.Values.ToArray().Distinct().ToArray().Count();
            if ( numIsland == 1 ) return true; else return false;
        }
        /// <summary>
        /// Find all island grid.
        /// </summary>
        /// <returns></returns>
        public Dictionary<int,int> FindIslandGrid ()
        {
            if (this.Buses.Count()    < 2) return new Dictionary<int, int>();
            if (this.Branches.Count() < 1) return new Dictionary<int, int>();
            Dictionary<int,int> dicBuses = new Dictionary<int, int>();            
            int ind = 0;
            foreach (int busId in this.Buses.Keys.ToList()) dicBuses.Add(busId,ind++); 

            bool FlagChange = true;
            
            int[] keys = this.Branches.Keys.ToArray();
            while (FlagChange)
            {
                FlagChange = false;
                for (ind=0; ind < keys.Count(); ind++ )
                {
                    int s = this.Branches[keys[ind]].StartBusId;
                    int f = this.Branches[keys[ind]].FinalBusId;
                    if (dicBuses[s] < dicBuses[f]) {dicBuses[f] = dicBuses[s]; FlagChange=true; continue;}
                    if (dicBuses[f] < dicBuses[s]) {dicBuses[s] = dicBuses[f]; FlagChange=true; continue;}
                }
            }        
            return dicBuses;
        }
    }
}