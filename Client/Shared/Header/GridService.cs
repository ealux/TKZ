using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKZ.Client.Shared.Header
{
    public class GridService
    {
        public string CurrentGridName { get; set; }

        public event Action OnChange;

        public GridService()
        {
            CurrentGridName = "stock";
        }
    }
}
