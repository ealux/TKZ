using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TKZ.Client.Pages.Log
{
    public class LogBase
    {
        public ObservableCollection<Message> Messages { get; set; }

        public bool Collapse { get; set; } = true;

        public event Action OnChange;

        public LogBase()
        {
            Messages = new ObservableCollection<Message>()
            {
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!", "contacts"),
            };
        }

        public async Task AddMessage(Message mes)
        {
            await Task.Run(() => Messages.Add(mes));
            OnChange?.Invoke();
        }

        public async Task RemoveMessage()
        {
            await Task.Run(() => Messages.Clear());
            OnChange?.Invoke();
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