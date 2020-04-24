namespace TKZ.Shared.Model
{
    public class Elem
    {
        protected int m_id;

        public bool IsActive { get; set; } = true;

        public string Name { get; set; } = "Noname";

        public int Id { get => m_id; }

        public override string ToString()
        {
            return Name;
        }
    }
}