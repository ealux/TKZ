using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TKZ.Shared.Model;

namespace TKZ.Shared
{
    public partial class Grid
    {
        
        public static Grid GetInstance()
        {
            if(CurrentGrid == null)
            {
                CurrentGrid = new Grid();
            }
            return CurrentGrid;
        }

        //Заготовки для методов сериализации
        public async Task<string> Serialize()
        {
            return await Task.Run(()=>{ return JsonConvert.SerializeObject(this); });
        }

        public static async Task<Grid> Deserialize(string json)
        {
            Grid grid = await Task.Run(()=> { return JsonConvert.DeserializeObject<Grid>(json); });
            return grid;
        }
    }
}