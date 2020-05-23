namespace TKZ.Shared.Model
{
    public class Bus : Elem
    {
        private static int m_curId = 1;
        private static int curId { get { return m_curId++; } }

        public double Unom { get; set; }

        public Bus()
        {
            this.m_id = curId;
        }

        public Bus(double Unom, string Name = "Noname")
        {
            this.m_id = curId;
            this.Unom = Unom;
            this.Name = Name;
        }

        public Bus(Bus other)
        {
            this.m_id = curId;
            this.Name = other.Name;
            this.Unom = other.Unom;
            this.IsActive = other.IsActive;
        }
    }
}