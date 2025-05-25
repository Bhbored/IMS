using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.MVVM.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Product
    {
        public int ProductID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryID { get; set; }
        public int SupplierID { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; } 
    }

}
