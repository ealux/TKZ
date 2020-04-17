using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TKZ.Client.Pages.Log
{
    public class LogBase
    {
        public ObservableCollection<Message> Messages { get; set; }

        public LogBase()
        {
            Messages = new ObservableCollection<Message>()
            {
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
            };
        }

        public async Task AddMessage(Message mes)
        {
            await Task.Run(() => Messages.Add(mes));
        }

        public async Task RemoveMessage()
        {
            await Task.Run(() => Messages.Clear());//Messages.Remove(Messages.Where((m) => m.elem.Id == el.Id).First());
        }

        /// <summary>
        /// Change log image source depending on the log messages count
        /// </summary>
        /// <returns><b>string</b>: Log image source</returns>
        public string ImageChecker()
        {
            string src = Messages.Count == 0 ? "img/bell.svg" : "img/bell_content.svg";
            return src;
        }
    }
}