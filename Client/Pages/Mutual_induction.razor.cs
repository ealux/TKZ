using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKZ.Client.Pages.Log;
using TKZ.Shared.Model;

namespace TKZ.Client.Pages
{
    public partial class Mutual_induction
    {
        //Валидаторы
        private async Task ValidateOnRender()
        {
            //Отчистка лога
            if (Log.Messages.Any((m) => m.Class == MessageClass.Mutuals)) await Log.RemoveMessage(byClass: MessageClass.Mutuals);
            //Проверка на отсутствие ветви начала и конца
            try
            {
                var IdList = mutuals.Select(b => b.IdFirstBranch).ToList()
                                 .Union(mutuals.Select(b => b.IdSecondBranch).ToList())
                                 .Distinct().ToList()
                                 .Except(grid.Branches.Values.Select(b => b.Id).ToList())
                                 .ToList() ?? null;

                await Task.Run(() =>
                {
                    if (IdList.Count > 0)
                    {
                        List<Mutual> signed = new List<Mutual>();
                        foreach (var mut in mutuals.Distinct().ToList())
                        {
                            if (signed.Any(m => m.IdFirstBranch == mut.IdFirstBranch
                                                && m.IdSecondBranch == mut.IdSecondBranch
                                                && m.R == mut.R
                                                && m.X == mut.X)) continue;

                            if (IdList.Contains(mut.IdFirstBranch) & IdList.Contains(mut.IdSecondBranch))
                            {
                                Log.AddMessage(MessageCollection.Mutual_OrphanError());
                                signed.Add(mut);
                                continue;
                            }

                            foreach (var orphanId in IdList)
                            {
                                if (mut.IdFirstBranch == orphanId)
                                {
                                    Log.AddMessage(MessageCollection.Mutual_IdError(IsStartId: true, restBranchName: grid.Branches[mut.IdSecondBranch].Name));
                                    signed.Add(mut);
                                }
                                else if (mut.IdSecondBranch == orphanId)
                                {
                                    Log.AddMessage(MessageCollection.Mutual_IdError(IsStartId: false, restBranchName: grid.Branches[mut.IdFirstBranch].Name));
                                    signed.Add(mut);
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
                var query = grid.Mutuals.Values.GroupBy(x => new
                {
                    _idStart = x.IdFirstBranch,
                    _idEnd = x.IdSecondBranch,
                    _R = x.R,
                    _X = x.X
                })
                                               .Where(g => g.Count() > 1)
                                               .Select(y => y.Key).ToList();
                await Task.Run(() =>
                {
                    if (query.Count > 0)
                    {
                        foreach (var item in query)
                        {
                            var start = !grid.Branches.ContainsKey(item._idStart) ? "" : grid.Branches[item._idStart].Name + ";";
                            var end = !grid.Branches.ContainsKey(item._idEnd) ? "" : grid.Branches[item._idEnd].Name;
                            Log.AddMessage(MessageCollection.Mutual_Duplicates(start, end));
                        }
                        Log.Collapse = false;
                    }
                });
            }
            catch (Exception) { return; }
        }
    }
}