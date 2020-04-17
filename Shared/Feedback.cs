using System;
using System.Globalization;
using System.Text;

namespace TKZ.Shared
{
    public class Feedback
    {
        public DateTime Datetime { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{\"DateTime\":\t\t\"" + this.Datetime.ToString(new CultureInfo("ru-RU")) + "\",");
            sb.AppendLine("\"Name\":\t\t\t\"" + this.Name.ToString(new CultureInfo("ru-RU")) + "\",");
            sb.AppendLine("\"E-mail\":\t\t\"" + this.Email.ToString(new CultureInfo("ru-RU")) + "\",");
            sb.AppendLine("\"Message\":\t\t\"" + this.Message.ToString(new CultureInfo("ru-RU")) + "\"},");
            return sb.ToString();
        }
    }
}