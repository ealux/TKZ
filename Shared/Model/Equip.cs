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

        public double E { get; set; }
        public double Fi_E { get; set; }


        public Equip()
        {
            this.m_id = CurId;
        }
    }
}
