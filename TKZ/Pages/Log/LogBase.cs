using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace TKZ.Pages.Log
{
    public class LogBase
    {
        //public static int id_counter { get; set; }

        public static string bell_src { get; set; }

        public static ObservableCollection<Message> Messages { get; set; }      

        public LogBase()
        {
            Messages = new ObservableCollection<Message>()
            {
                new Message(Message.MessageType.Success, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Warning, "Внимание!", "У нас кончилась водка!"),
                new Message(Message.MessageType.Danger, "Внимание!", "У нас кончилась водка!")
            };
        }

        public static void AddMessage(Message mes)
        {
            Messages.Add(mes);
        }

        public static void RemoveMessage()
        {
            Messages.Clear();//Messages.Remove(Messages.Where((m) => m.elem.Id == el.Id).First());
        }

        /// <summary>
        /// Change log image source depending on the log messages count
        /// </summary>
        /// <returns><b>string</b>: Log image source</returns>
        public static string ImageChecker()
        {
            string src = Task.Run(()=>Messages.Count == 0 ? "img/bell.png" : "img/bell_content.png").GetAwaiter().GetResult();
            return src;
        }        
    }
}
