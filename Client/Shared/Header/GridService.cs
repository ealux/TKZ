using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TKZ.Client.Shared.Header
{
    public class GridService
    {
        private string currentname;

        public string CurrentGridName
        {
            get => currentname;
            set
            {
                OnChange?.Invoke();
                currentname = value;
            }
        }

        public event Action OnChange;

        public GridService()
        {
            currentname = "stock";
        }
    }
}
