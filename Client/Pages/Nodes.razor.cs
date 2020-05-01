using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKZ.Client.Pages.Log;

namespace TKZ.Client.Pages
{
    public partial class Nodes
    {
        
        //Валидаторы
        private async Task ValidateOnRender()
        {
            //Отчистка лога
            if (Log.Messages.Any((m) => m.Class == MessageClass.Nodes)) await Log.RemoveMessage(byClass: MessageClass.Nodes);
            //Duplicates
            try
            {
                var query = grid.Buses.Values.GroupBy(x => new{ _Name = x.Name, _Unom = x.Unom })
                                               .Where(g => g.Count() > 1)
                                               .Select(y => y.Key).ToList();
                await Task.Run(() =>
                {
                    if (query.Count > 0)
                    {
                        foreach (var item in query) Log.AddMessage(MessageCollection.Node_Duplicates(item._Name));
                        Log.Collapse = false;
                    }
                });
            }
            catch (Exception) { return; }

        }
    }
}
