using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            Messages = new ObservableCollection<Message>();
        }

        public async void AddMessage(Message mes)
        {
            if (!this.Messages.Contains(mes))
            {
                await Task.Run(() => Messages.Add(mes));
                OnChange?.Invoke();
            }
        }

        public async Task RemoveMessage()
        {
            await Task.Run(() => Messages.Clear());
            OnChange?.Invoke();
        }

        public async Task RemoveMessage(MessageClass byClass)
        {
            await Task.Run(() => { foreach (var mes in Messages.Where(m => m.Class == byClass).ToList()) Messages.Remove(mes); });
            OnChange?.Invoke();
        }

        /// <summary>
        /// Change log image source depending on the log messages count
        /// </summary>
        /// <returns><b>string</b>: Log image source</returns>
        public string ImageChecker() => Messages.Count == 0 ? "/img/Icon.svg#bell" : "/img/Icon.svg#bell_content";
    }
}