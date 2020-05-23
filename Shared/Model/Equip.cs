using System;
using System.Collections.Generic;
using System.Text;

namespace TKZ.Shared.Model
{
    public class Equip : Elem
    {
        private static int m_curId = 1;
        private static int CurId { get { return m_curId++; } }

        public int BusId { get; set; }

        public double R { get; set; }
        public double X { get; set; }

        public double R2 { get; set; }
        public double X2 { get; set; }

        public double R0 { get; set; }
        public double X0 { get; set; }

        public double E { get; set; }
        public double Fi_E { get; set; }


        public Equip()
        {
            this.m_id = CurId;
        }

        public Equip(int busId, double r, double x,
                     string name,
                     double e, double fi_e)
        {
            this.m_id = CurId;
            this.BusId = busId;
            this.Name = name;
            this.R = r;
            this.X = x;
            this.E = e;
            this.Fi_E = fi_e;
        }

        public Equip(Equip other, int newBusId)
        {
            this.m_id = CurId;
            this.BusId = newBusId;
            this.Name = other.Name;
            this.IsActive = other.IsActive;
            this.R = other.R;
            this.X = other.X;
            this.R2 = other.R2;
            this.X2 = other.X2;
            this.R0 = other.R0;
            this.X0 = other.X0;
            this.E = other.E;
            this.Fi_E = other.Fi_E;
        }
    }
}
