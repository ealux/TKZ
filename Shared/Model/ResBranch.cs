using System.Numerics;

namespace TKZ.Shared.Model
{
    /// <summary>
    /// Хранения результатов расчётов по ветвям.
    /// </summary>
    public class ResBranch:Elem
    {
        public Complex StartI0 {get; set;}
        public Complex StartI1 {get; set;}
        public Complex StartI2 {get; set;}
        public Complex StartIa {get; set;}
        public Complex StartIb {get; set;}
        public Complex StartIc {get; set;}

        public Complex FinalI0 {get; set;}
        public Complex FinalI1 {get; set;}
        public Complex FinalI2 {get; set;}
        public Complex FinalIa {get; set;}
        public Complex FinalIb {get; set;}
        public Complex FinalIc {get; set;}

        public Complex StartZ0 {get; set;}
        public Complex StartZ1 {get; set;}
        public Complex StartZ2 {get; set;}
        public Complex StartZa {get; set;}
        public Complex StartZb {get; set;}
        public Complex StartZc {get; set;}

        public Complex FinalZ0 {get; set;}
        public Complex FinalZ1 {get; set;}
        public Complex FinalZ2 {get; set;}
        public Complex FinalZa {get; set;}
        public Complex FinalZb {get; set;}
        public Complex FinalZc {get; set;}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">Id source Branch.</param>
        public ResBranch(int Id)
        {
            this.m_id = Id;
            StartI0 = new Complex();
            StartI1 = new Complex();
            StartI2 = new Complex();
            StartIa = new Complex();
            StartIb = new Complex();
            StartIc = new Complex();

            FinalI0 = new Complex();
            FinalI1 = new Complex();
            FinalI2 = new Complex();
            FinalIa = new Complex();
            FinalIb = new Complex();
            FinalIc = new Complex();

            StartZ0 = new Complex();
            StartZ1 = new Complex();
            StartZ2 = new Complex();
            StartZa = new Complex();
            StartZb = new Complex();
            StartZc = new Complex();

            FinalZ0 = new Complex();
            FinalZ1 = new Complex();
            FinalZ2 = new Complex();
            FinalZa = new Complex();
            FinalZb = new Complex();
            FinalZc = new Complex();                    
        }
    }
}