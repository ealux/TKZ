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
    }
}
