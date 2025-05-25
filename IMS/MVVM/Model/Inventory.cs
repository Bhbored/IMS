using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.MVVM.Model
{
    public class Inventory
    {
        public ObservableCollection<Product>? CurrentInventory { get; set; }

    }
}
