namespace TKZ.Client.Model
{    
    public class Elem
    {
 
        public int m_id;

        private string m_name="Noname";

        public string Name { get => m_name; set => m_name = value; }

        public int Id { get => m_id;}
    }
}