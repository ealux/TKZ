using System;

namespace TKZ.Client.Model
{    
    public class Branch:Elem
    {
        private static int m_curId = 1;
        private static int curId { get { m_curId += 1; return m_curId - 1; } }

        public int StIdBus { get => m_stIdBus; set => m_stIdBus = value; }
        public int FinIdBus { get => m_finIdBus; set => m_finIdBus = value; }
        public double R1 { get => m_R1; set => m_R1 = value; }
        public double X1 { get => m_X1; set => m_X1 = value; }
        public double R0 { get => m_R0; set => m_R0 = value; }
        public double X0 { get => m_X0; set => m_X0 = value; }
        public double StUnom { get => m_stUnom; set => m_stUnom = value; }
        public double FinUnom { get => m_finUnom; set => m_finUnom = value; }
        public bool GroundStBus { get => m_groundStBus; set => m_groundStBus = value; }
        public bool GroundFinBus { get => m_groundFinBus; set => m_groundFinBus = value; }

        private int m_stIdBus;
        private int m_finIdBus;

        private double m_R1;
        private double m_X1;
        private double m_R0;
        private double m_X0;
        private double m_stUnom;
        private double m_finUnom;
        private bool m_groundStBus = false;
        private bool m_groundFinBus = false;

        public Branch(int stIdBus, int finIdBus, string NameBranch, double R1, double X1, double R0, double X0, double StUnom, double FinUnom, bool GroundStBus, bool GroundFinBus)
        {
            this.m_id = Branch.curId;
            this.StIdBus = stIdBus;
            this.FinIdBus = finIdBus;             
            this.R1 = R1;
            this.X1 = X1;
            this.R0 = R0;
            this.X0 = X0;
            this.StUnom = StUnom;
            this.FinUnom = FinUnom;
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

        }

       public override string ToString()
        {
            return Name;
        }
    }
}