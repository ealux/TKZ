using System;

namespace TKZ.Shared.Model
{    
    public class Bus:Elem    
    {
        private static int m_curId = 1;
        private static int curId { get { return m_curId++; } }

        public double Unom { get; set; }
 
        public Bus(double Unom, string Name="Noname", bool IsGround = false)
        {
            if (IsGround)
            {
                this.m_id = 0;
            }
            else
            {
                this.m_id = curId;
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