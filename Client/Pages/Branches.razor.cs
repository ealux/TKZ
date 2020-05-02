using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKZ.Client.Pages.Log;
using TKZ.Shared.Model;

namespace TKZ.Client.Pages
{
    public partial class Branches
    {
        private async Task ValidateOnRender()
        {
            //Отчистка лога
            if (Log.Messages.Any((m) => m.Class == MessageClass.Branches)) await Log.RemoveMessage(byClass: MessageClass.Branches);
            //Проверка на отсутствие ветви начала и конца
            try
            {
                var IdList = branches.Select(b => b.StartBusId).ToList()
                                 .Union(branches.Select(b => b.FinalBusId).ToList())
                                 .Distinct().ToList()
                                 .Except(grid.Buses.Values.Select(b => b.Id).ToList())
                                 .ToList() ?? null;

                await Task.Run(() =>
                {
                    if (IdList.Count > 0)
                    {
                        List<Branch> signed = new List<Branch>();
                        foreach (var branch in branches)
                        {
                            if (signed.Any(b => b.StartBusId == branch.StartBusId && b.FinalBusId == branch.FinalBusId && b.Name == branch.Name)) continue;
                            foreach (var orphanId in IdList)
                            {
                                if (branch.StartBusId == orphanId)
                                {
                                    Log.AddMessage(MessageCollection.Branch_IdError(IsStartId: true, branchName: branch.Name));
                                    signed.Add(branch);
                                }
                                if (branch.FinalBusId == orphanId)
                                {
                                    Log.AddMessage(MessageCollection.Branch_IdError(IsStartId: false, branchName: branch.Name));
                                    signed.Add(branch);
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
                var query = grid.Branches.Values.GroupBy(x => new { _Name = x.Name, _start = x.StartBusId, _end = x.FinalBusId }).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
                await Task.Run(() =>
                {
                    if (query.Count > 0) foreach (var item in query) { Log.AddMessage(MessageCollection.Branch_Duplicates(item._Name)); Log.Collapse = false; }
                });
            }
            catch (Exception) { return; }
        }
    }
}