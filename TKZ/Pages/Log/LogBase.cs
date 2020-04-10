using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using TKZ.Shared;

namespace TKZ.Pages.Log
{
    public class LogBase
    {
        public static ObservableCollection<Message> Messages { get; set; }      

        public LogBase()
        {
            Messages = new ObservableCollection<Message>()
            {
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Warning, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Danger, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Warning, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Danger, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Warning, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Danger, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Warning, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Danger, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Warning, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Danger, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Warning, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Danger, "Внимание!", "У нас кончилась водка!")
            };
        }

        public static async Task AddMessage(Message mes)
        {
            await Task.Run(()=>Messages.Add(mes));
        }

        public static async Task RemoveMessage()
        {
            await Task.Run(()=>Messages.Clear());//Messages.Remove(Messages.Where((m) => m.elem.Id == el.Id).First());
        }

        /// <summary>
        /// Change log image source depending on the log messages count
        /// </summary>
        /// <returns><b>string</b>: Log image source</returns>
        public static string ImageChecker()
        {
            string src = Task.Run(() => Messages.Count == 0 ? "img/bell.svg" : "img/bell_content.svg").GetAwaiter().GetResult();
            return src;
        }        
    }
}
