namespace TKZ.Client.Model
{    
    public class Bus:Elem    
    {
        private static int m_curId = 1;
        private static int curId { get { m_curId += 1; return m_curId - 1; } }


        public double Unom { get => m_unom; set => m_unom = value; }

        private double m_unom;        

        public Bus(double Unom, string Name="Noname", bool Ground = false)
        {
            if (Ground)
            {
                this.m_id = 0;
            }
            else
            {
                this.m_id = Bus.curId;
            }            
            this.Unom = Unom;
            this.Name = Name;
        }

       public override string ToString()
        {
            return Name;
        }
    
    }
}