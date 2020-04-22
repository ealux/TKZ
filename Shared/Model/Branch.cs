using System;

namespace TKZ.Shared.Model
{    
    public class Branch:Elem
    {
        private static int m_curId = 1;
        private static int curId { get { return m_curId++; } }
        public int NumPar {get; set;}
        public int StartBusId { get; set; }
        public int FinalBusId { get; set; }
        public double R1 { get; set; }
        public double X1 { get; set; }
        public double R0 { get; set; }
        public double X0 { get; set; }
        public double StUnom { get; set; }
        public double FinUnom { get; set; }
        public bool GroundStBus { get; set; }
        public bool GroundFinBus { get; set; }
        public double Fi_trans { get; set; }
        public double E { get; set; }
        public double Fi_E { get; set; }

        public Branch()
        {
            this.m_id = Branch.curId;
        }

        public Branch(int startBusId, int finalBusId, string NameBranch, 
                      double R1, double X1, double R0, double X0, 
                      double StUnom, double FinUnom, double Fi_trans, 
                      bool GroundStBus, bool GroundFinBus, 
                      double E, double Fi_E)
        {
            this.m_id = Branch.curId;
            this.StartBusId = startBusId;
            this.FinalBusId = finalBusId;             
            this.R1 = R1;
            this.X1 = X1;
            this.R0 = R0;
            this.X0 = X0;
            this.StUnom = StUnom;
            this.FinUnom = FinUnom;
            this.Fi_trans = Fi_trans;
            this.GroundStBus = GroundStBus;
            this.GroundFinBus = GroundFinBus;
            string str ="";
            if (NameBranch == "")
            {
                str = "Noname" + Convert.ToString(this.Id);
                this.Name = str;
            }       
            else
            {
                this.Name = NameBranch;
            }     
            this.E = E;
            this.Fi_E = Fi_E;

        }
    }
}