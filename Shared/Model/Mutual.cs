namespace TKZ.Shared.Model
{
    public class Mutual : Elem
    {
        private static int m_curId = 1;
        private static int CurId { get { return m_curId++; } }

        public int IdFirstBranch { get; set; }
        public int IdSecondBranch { get; set; }
        public double X { get; set; }
        public double R { get; set; }

        public Mutual()
        {
            this.m_id = CurId;
        }

        public Mutual(int IdFirstBranch, int IdSecondBranch, double R, double X)
        {
            this.m_id = CurId;
            this.IdFirstBranch = IdFirstBranch;
            this.IdSecondBranch = IdSecondBranch;
            this.R = R;
            this.X = X;
        }

        public Mutual(Mutual other, int newIdFirstBranch, int newIdSecondBranch)
        {
            this.m_id = CurId;
            this.Name = other.Name;
            this.IsActive = other.IsActive;
            this.IdFirstBranch = newIdFirstBranch;
            this.IdSecondBranch = newIdSecondBranch;
            this.R = other.R;
            this.X = other.X;
        }
    }
}