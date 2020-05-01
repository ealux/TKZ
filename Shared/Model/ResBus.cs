using System.Numerics;

namespace TKZ.Shared.Model
{
    /// <summary>
    /// Хранение результатов расчётов по узлам.
    /// </summary>
    public class ResBus:Elem
    {
        public Complex U0 { get; set; }
        public Complex U1 { get; set; }
        public Complex U2 { get; set; }
        public Complex Ua { get; set; }
        public Complex Ub { get; set; }
        public Complex Uc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">Id source bus.</param>
        public ResBus(int Id)
        {
            this.m_id = Id;
            U0 = new Complex();
            U1 = new Complex();
            U2 = new Complex();
            Ua = new Complex();
            Ub = new Complex();
            Uc = new Complex();
        }
    }
}