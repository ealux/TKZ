using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKZ.Client.Pages.Log;
using TKZ.Shared.Model;

namespace TKZ.Client.Pages
{
    public partial class Equipment
    {
        //Валидаторы
        private async Task ValidateOnRender()
        {
            //Отчистка лога
            if (Log.Messages.Any((m) => m.Class == MessageClass.Equipment)) await Log.RemoveMessage(byClass: MessageClass.Equipment);

            //Проверка на отсутствие ветви начала и конца
            try
            {
                var IdList = equipment.Select(b => b.BusId).ToList()
                                     .Distinct().ToList()
                                     .Except(grid.Buses.Values.Select(b => b.Id).ToList())
                                     .ToList() ?? null;

                await Task.Run(() =>
                {
                    if (IdList.Count > 0)
                    {
                        List<Equip> signed = new List<Equip>();
                        foreach (var eq in equipment)
                        {
                            if (signed.Any(b => b.BusId == eq.BusId && b.Name == eq.Name)) continue;
                            foreach (var orphanId in IdList)
                            {
                                if (eq.BusId == orphanId)
                                {
                                    Log.AddMessage(MessageCollection.Equipment_IdError(equipName: eq.Name));
                                    signed.Add(eq);
                                }
                            }
                        }
                        Log.Collapse = false;
                    }
                });
            }
            catch (Exception) { return; }

            //Duplicates
            try
            {
                var query = grid.Equipment.Values.GroupBy(x => new { _Name = x.Name, _R = x.R, _X = x.X, _E = x.E, _Fi_E = x.Fi_E })
                                               .Where(g => g.Count() > 1)
                                               .Select(y => y.Key).ToList();
                await Task.Run(() =>
                {
                    if (query.Count > 0)
                    {
                        foreach (var item in query) Log.AddMessage(MessageCollection.Equipment_Duplicates(item._Name));
                        Log.Collapse = false;
                    }
                });
            }
            catch (Exception) { return; }

            //Similar Names
            try
            {
                var query = grid.Equipment.Values.Where(n => grid.Equipment.Values.Where(i => i != n).Any(comp => n.Name == comp.Name 
                                                                                                                  && n.R != comp.R
                                                                                                                  && n.X != comp.X
                                                                                                                  && n.E != comp.E
                                                                                                                  && n.Fi_E != comp.Fi_E)).Distinct().ToList();

                await Task.Run(() =>
                {
                    if (query.Count > 0)
                    {
                        List<Equip> signed = new List<Equip>();
                        foreach (var item in query)
                        {
                            if (!signed.Any(n => n.Name == item.Name))
                            {
                                Log.AddMessage(MessageCollection.Equipment_SimilarNames(item.Name));
                                signed.Add(item);
                            }
                        }
                        Log.Collapse = false;
                    }
                });
            }
            catch (Exception) { return; }
        }
    }
}
