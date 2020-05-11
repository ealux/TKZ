using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TKZ.Shared.Model;

namespace TKZ.Shared
{
    public partial class Grid
    {       
        //Заготовки для методов сериализации
        public async Task<string> Serialize() //работает
        {
            return await Task.Run(()=>{ return JsonConvert.SerializeObject(this); });
        }

        public static async Task<Grid> Deserialize(string json) //не работает + продумать по ID
        {
            Grid grid = await Task.Run(()=> { return JsonConvert.DeserializeObject<Grid>(json); });
            return grid;
        }
    }
}