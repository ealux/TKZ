using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TKZ.Shared.Model;

namespace TKZ.Shared
{
    public partial class Grid
    {
        //Заготовки для методов сериализации
        public async Task<string> Serialize() //работает
        {
            return await Task.Run(() => { return JsonConvert.SerializeObject(this); });
        }

        public static async Task<Grid> Deserialize(Stream stream)
        {
            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            return await Deserialize(sr.ReadToEnd());
        }

        public static async Task<Grid> Deserialize(string json)
        {
            Grid grid = new Grid();

            await Task.Run(() =>
            {
                JObject o = JObject.Parse(json);
                grid.Name = (string)o["Name"];
                grid.ArcR = (double)o["ArcR"];
                grid.ArcX = (double)o["ArcX"];

                Dictionary<int, Bus> tmpBuses = new Dictionary<int, Bus>();
                foreach (var item in o["Buses"])
                {
                    foreach (var item2 in item)
                    {
                        Bus b = new Bus()
                        {
                            Unom = (double)item2["Unom"],
                            IsActive = (bool)item2["IsActive"],
                            Name = (string)item2["Name"]
                        };
                        tmpBuses.Add((int)item2["Id"], b);
                        grid.Buses.Add(b.Id, b);
                    }
                }

                foreach (var item in o["Equipment"])
                {
                    foreach (var item2 in item)
                    {
                        Equip e = new Equip()
                        {
                            BusId = tmpBuses.ContainsKey((int)item2["BusId"]) ? tmpBuses[(int)item2["BusId"]].Id : default,
                            R = (double)item2["R"],
                            X = (double)item2["X"],
                            E = (double)item2["E"],
                            Fi_E = (double)item2["Fi_E"],
                            IsActive = (bool)item2["IsActive"],
                            Name = (string)item2["Name"]
                        };
                        grid.Equipment.Add(e.Id, e);
                    }
                }

                Dictionary<int, Branch> tmpBranches = new Dictionary<int, Branch>();
                foreach (var item in o["Branches"])
                {
                    foreach (var item2 in item)
                    {
                        Branch br = new Branch()
                        {
                            NumPar = (int)item2["NumPar"],
                            StartBusId = tmpBuses.ContainsKey((int)item2["StartBusId"]) ? tmpBuses[(int)item2["StartBusId"]].Id : default,
                            FinalBusId = tmpBuses.ContainsKey((int)item2["FinalBusId"]) ? tmpBuses[(int)item2["FinalBusId"]].Id : default,
                            R1 = (double)item2["R1"],
                            X1 = (double)item2["X1"],
                            R0 = (double)item2["R0"],
                            X0 = (double)item2["X0"],
                            StUnom = (double)item2["StUnom"],
                            FinUnom = (double)item2["FinUnom"],
                            GroundStBus = (int)item2["GroundStBus"] == 0 ? GroundMode.Ground
                                                                         : (int)item2["GroundStBus"] == 1 ?
                                                                                        GroundMode.NonGrnd : GroundMode.Disabled,
                            GroundFinBus = (int)item2["GroundFinBus"] == 0 ? GroundMode.Ground
                                                                           : (int)item2["GroundFinBus"] == 1 ?
                                                                                        GroundMode.NonGrnd : GroundMode.Disabled,
                            Fi_trans = (double)item2["Fi_trans"],
                            B = (double)item2["B"],
                            G = (double)item2["G"],
                            B0 = item2["B0"] != null ? (double)item2["B0"] : default,
                            G0 = item2["G0"] != null ? (double)item2["G0"] : default,
                            IsActive = (bool)item2["IsActive"],
                            Name = (string)item2["Name"]
                        };
                        tmpBranches.Add((int)item2["Id"], br);
                        grid.Branches.Add(br.Id, br);
                    }
                }

                foreach (var item in o["Mutuals"])
                {
                    foreach (var item2 in item)
                    {
                        Mutual m = new Mutual()
                        {
                            IdFirstBranch = tmpBranches.ContainsKey((int)item2["IdFirstBranch"]) ? tmpBranches[(int)item2["IdFirstBranch"]].Id : default,
                            IdSecondBranch = tmpBranches.ContainsKey((int)item2["IdSecondBranch"]) ? tmpBranches[(int)item2["IdSecondBranch"]].Id : default,
                            R = (double)item2["R"],
                            X = (double)item2["X"],
                            IsActive = (bool)item2["IsActive"],
                            Name = (string)item2["Name"]
                        };
                        grid.Mutuals.Add(m.Id, m);
                    }
                }
            });

            return grid;
        }
    }
}