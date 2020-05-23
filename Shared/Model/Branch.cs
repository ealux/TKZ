using System;

namespace TKZ.Shared.Model
{
    public class Branch : Elem
    {
        private static int m_curId = 1;
        private static int CurId { get { return m_curId++; } }
        public int NumPar { get; set; }
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
        /// <summary>
        /// Branch ground conductivity.
        /// - indeuctive; + capacity
        /// </summary>
        /// <value></value>
        public double B { get; set; }
        /// <summary>
        /// Branch ground conductivity (active).
        /// </summary>
        /// <value></value>
        public double G { get; set; }
        /// <summary>
        /// Branch ground conductivity  on graund.
        /// - indeuctive; + capacity
        /// </summary>
        /// <value></value>
        public double B0 { get; set; }
        /// <summary>
        /// Branch ground conductivity (active) on graund.
        /// </summary>
        /// <value></value>
        public double G0 { get; set; }
        /// <summary>
        /// Ratio transformer. St Bus U / Fin Bus U.
        /// </summary>
        /// <value>Ratio value.</value>
        public double Ratio
        {
            get
            {
                double r = 0;
                if (FinUnom > 0) r = StUnom / FinUnom;
                return r;
            }
        }
        public Branch()
        {
            this.m_id = Branch.CurId;
        }

        public Branch(int startBusId, int finalBusId, string NameBranch,
                      double R1, double X1, double R0, double X0,
                      double StUnom, double FinUnom, double Fi_trans,
                      bool GroundStBus, bool GroundFinBus, 
                      double B = 0, double G = 0, double B0 = 0, double G0 = 0)
        {
            this.m_id = Branch.CurId;
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
            this.Name = NameBranch;            
            this.B = B;
            this.G = G;
            this.B0 = B0;
            this.G0 = G0;
        }

        public Branch(Branch other, int newStartBusId, int newFinBusId)
        {
            this.m_id = Branch.CurId;
            this.StartBusId = newStartBusId;
            this.FinalBusId = newFinBusId;
            this.R1 = other.R1;
            this.X1 = other.X1;
            this.R0 = other.R0;
            this.X0 = other.X0;
            this.StUnom = other.StUnom;
            this.FinUnom = other.FinUnom;
            this.Fi_trans = other.Fi_trans;
            this.GroundStBus = other.GroundStBus;
            this.GroundFinBus = other.GroundFinBus;
            this.Name = other.Name;
            this.B = other.B;
            this.G = other.G;
            this.B0 = other.B0;
            this.G0 = other.G0;
            this.IsActive = other.IsActive;
        }
    }
}