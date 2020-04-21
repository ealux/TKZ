using System;
using System.Linq;
using System.Collections.Generic;
using TKZ.Shared.Model;
using System.Globalization;

namespace TKZ.Shared
{    
    public class Grid
    {
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
            Bus b1 = new Bus(100,"333");
            Bus b2 = new Bus(100,"FFFFF");
            this.Buses.Add(b1.Id,b1);        
            this.Buses.Add(b2.Id,b2);

            Branch br1 = new Branch(b1.Id,b2.Id,"Ветка 1",1,2,3,4,5,6,7, false, true, 44,0);
            Branch br2 = new Branch(b2.Id,b1.Id,"",3,4,5,6,7,8,6, true, false,33,0);   
            Branch br3 = new Branch(b2.Id,b1.Id,"",3,4,5,6,7,8,7, true, true,44,4);          
            Branch br4 = new Branch(b2.Id,b1.Id,"",3,4,5,6,7,8,6, false, false,33,2); 

            this.Branches.Add(br1.Id,br1); 
            this.Branches.Add(br2.Id,br2);
            this.Branches.Add(br3.Id,br3);
            this.Branches.Add(br4.Id,br4);

            Console.WriteLine(br4.Id);

            Mutual m1 = new Mutual(br1.Id,br2.Id,1,2);
            Mutual m2 = new Mutual(br3.Id,br4.Id,13,2);

            this.Mutuals.Add(m1.Id,m1);
            this.Mutuals.Add(m2.Id,m2);
        }      

        public List<int> FindBranchBelt(int idBus, int numBelt=1)
        {
            if (numBelt <1) numBelt = 1;

            Dictionary<int,bool> dicBranches = new Dictionary<int, bool>();
            Dictionary<int,bool> dicBuses = new Dictionary<int, bool>();
            foreach (Branch b in Branches.Values.ToList()) dicBranches.Add(b.Id,false);
            foreach (Bus b in Buses.Values.ToList()) dicBuses.Add(b.Id,false);

            RecursiveFindBeltBranch(dicBranches,dicBuses,idBus,numBelt);
            
            List<int> res = new List<int>();                        
            foreach (int i in dicBranches.Keys) if (dicBranches[i] == true) res.Add(i);            
            return res;
        }   
        private void RecursiveFindBeltBranch(Dictionary<int,bool> dicBranches,Dictionary<int,bool> dicBuses,int BusId,int Belt)
        {
            dicBuses[BusId] = true;
            if (Belt < 1) return;

            int[] l = FindAllBranchOnBusID(BusId);
            for (int ind = 0; ind < l.Count(); ind++)
            {
                int cur = l[ind];
                dicBranches[cur] = true;
                if (Branches[cur].StIdBus  == BusId)
                {
                    if (dicBuses[Branches[cur].FinIdBus]==false) RecursiveFindBeltBranch (dicBranches, dicBuses,Branches[cur].FinIdBus,Belt - 1);
                    continue;
                }
                if (Branches[cur].FinIdBus == BusId) 
                {
                    if (dicBuses[Branches[cur].StIdBus]==false) RecursiveFindBeltBranch (dicBranches, dicBuses,Branches[cur].StIdBus, Belt - 1);
                    continue;
                }
            }
        }
        private int[] FindAllBranchOnBusID(int BusId)
        {            
            List<int> br = new List<int>();
            foreach (Branch b in Branches.Values )
            {
                if (b.StIdBus ==BusId ) br.Add(b.Id);
                if (b.FinIdBus==BusId) br.Add(b.Id);
            }
            int[] res = br.Distinct().ToArray();
            Array.Sort(res);
            return res;
        }
    }
}