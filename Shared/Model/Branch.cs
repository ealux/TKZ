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
                      bool GroundStBus, bool GroundFinBus, double B = 0, double G =0)
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
            string str;
            if (NameBranch == "")
            {
                str = Convert.ToString(startBusId)
                    + " - "
                    + Convert.ToString(FinalBusId)
                    + " "
                    + Convert.ToString(this.Id);
                this.Name = str;
            }
            else
            {
                this.Name = NameBranch;
            }
            this.B = B;
            this.G = G;
        }
    }
}