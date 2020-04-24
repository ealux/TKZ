namespace TKZ.Shared.Model
{
    public class Mutual : Elem
    {
        private static int m_curId = 1;
        private static int curId { get { return m_curId++; } }

        public int IdFirstBranch { get; set; }
        public int IdSecondBranch { get; set; }
        public double X { get; set; }
        public double R { get; set; }

        public Mutual()
        {
            this.m_id = curId;
        }

        public Mutual(int IdFirstBranch, int IdSecondBranch, double R, double X)
        {
            this.m_id = curId;
            this.IdFirstBranch = IdFirstBranch;
            this.IdSecondBranch = IdSecondBranch;
            this.R = R;
            this.X = X;
        }
    }
}