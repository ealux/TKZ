using System;
using System.Collections.Generic;
using TKZ.Client.Model;

namespace TKZ.Client
{    
    public class Grid
    {
        private Dictionary<int, Bus> m_Buses =  new Dictionary<int, Bus>();

        public Dictionary<int, Bus> Buses { get => m_Buses; set => m_Buses = value; }

        private Dictionary<int, Branch> m_Branches =  new Dictionary<int, Branch>();

        public Dictionary<int, Branch> Branches { get => m_Branches; set => m_Branches = value; }
        public Dictionary<int, Mutual> Mutuals { get => m_Mutuals; set => m_Mutuals = value; }

        private Dictionary<int, Mutual> m_Mutuals =  new Dictionary<int, Mutual>();

        public Grid()
        {
            //Test case. Erase on Realese.
            Bus b1 = new Bus(100,"333");
            Bus b2 = new Bus(100,"FFFFF");
            this.Buses.Add(b1.Id,b1);        
            this.Buses.Add(b2.Id,b2);

            Branch br1 = new Branch(b1.Id,b2.Id,"Ветка 1",1,2,3,4,5,6, false, true);
            Branch br2 = new Branch(b2.Id,b1.Id,"",3,4,5,6,7,8, true, false);   
            Branch br3 = new Branch(b2.Id,b1.Id,"",3,4,5,6,7,8, true, true);          
            Branch br4 = new Branch(b2.Id,b1.Id,"",3,4,5,6,7,8, false, false); 

            this.Branches.Add(br1.Id,br1); 
            this.Branches.Add(br2.Id,br2);
            this.Branches.Add(br3.Id,br3);
            this.Branches.Add(br4.Id,br4);

            Mutual m1 = new Mutual(br1.Id,br2.Id,1,2);
            Mutual m2 = new Mutual(br3.Id,br4.Id,13,2);

            this.Mutuals.Add(m1.Id,m1);
            this.Mutuals.Add(m2.Id,m2);
        }       
    }
}