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

        //Branch Model Class
        //private class BranchModel
        //{
        //    public int StartBusId { get; set; }
        //    public int FinalBusId { get; set; }

        //    public bool IsActive { get; set; } = true;
        //    public int Id { get; set; }
        //    public string StartBusName { get; set; }
        //    public string FinalBusName { get; set; }
        //    public string Name { get; set; } = "Noname";
        //    public double R1 { get; set; }
        //    public double X1 { get; set; }
        //    public double R0 { get; set; }
        //    public double X0 { get; set; }
        //    public double StUnom { get; set; }
        //    public double FinUnom { get; set; }
        //    public bool GroundStBus { get; set; }
        //    public bool GroundFinBus { get; set; }
        //    public double Fi_trans { get; set; }
        //    public double E { get; set; }
        //    public double Fi_E { get; set; }

        //    //ctor
        //    public BranchModel() { }

        //    public BranchModel(BranchModel item, int new_Id)
        //    {
        //        Id = new_Id;
        //        IsActive = item.IsActive;
        //        StartBusId = item.StartBusId;
        //        FinalBusId = item.FinalBusId;
        //        //other properties
        //        Name = item.Name;
        //        StartBusName = item.StartBusName;
        //        FinalBusName = item.FinalBusName;
        //        R1 = item.R1;
        //        X1 = item.X1;
        //        R0 = item.R0;
        //        X0 = item.X0;
        //        StUnom = item.StUnom;
        //        FinUnom = item.FinUnom;
        //        GroundStBus = item.GroundStBus;
        //        GroundFinBus = item.GroundFinBus;
        //        Fi_trans = item.Fi_trans;
        //        E = item.E;
        //        Fi_E = item.Fi_E;
        //    }

        //    //load data
        //    public static async Task<List<BranchModel>> LoadData(Grid local_grid)
        //    {
        //        List<BranchModel> output = new List<BranchModel>();

        //        var braches = await Task.Run(() => local_grid.Branches.Values.ToList());

        //        foreach (var item in braches)
        //        {
        //            output.Add(new BranchModel()
        //            {
        //                Id = item.Id,
        //                IsActive = item.IsActive,
        //                StartBusId = item.StartBusId,
        //                FinalBusId = item.FinalBusId,
        //                //other properties
        //                Name = item.Name,
        //                StartBusName = local_grid.Buses.ContainsKey(item.StartBusId) ? local_grid.Buses[item.StartBusId].Name : default(string),
        //                FinalBusName = local_grid.Buses.ContainsKey(item.FinalBusId) ? local_grid.Buses[item.FinalBusId].Name : default(string),
        //                R1 = item.R1,
        //                X1 = item.X1,
        //                R0 = item.R0,
        //                X0 = item.X0,
        //                StUnom = item.StUnom,
        //                FinUnom = item.FinUnom,
        //                GroundStBus = item.GroundStBus,
        //                GroundFinBus = item.GroundFinBus,
        //                Fi_trans = item.Fi_trans,
        //                E = item.E,
        //                Fi_E = item.Fi_E
        //            });
        //        }

        //        return output;
        //    }
        //}
    }
}