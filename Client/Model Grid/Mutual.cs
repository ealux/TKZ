namespace TKZ.Client.Model
{    
    public class Mutual:Elem
    {   
        private static int m_curId = 1;
        private static int curId { get { m_curId += 1; return m_curId - 1; } }

        public int IdFirstBranch { get => m_idFirstBranch; set => m_idFirstBranch = value; }
        public int IdSecondBranch { get => m_idSecondBranch; set => m_idSecondBranch = value; }
        public double X { get => m_X; set => m_X = value; }
        public double R { get => m_R; set => m_R = value; }

        private int m_idFirstBranch;
        private int m_idSecondBranch;

        private double m_R = 0;
        private double m_X = 0;

        public Mutual(int IdFirstBranch, int IdSecondBranch, double R, double X)
        {
            this.m_id = Mutual.curId;
            this.IdFirstBranch = IdFirstBranch;
            this.IdSecondBranch = IdSecondBranch;
            this.R = R;
            this.X = X;
        }

    }
}