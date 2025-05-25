using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.MVVM.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Orders
    {

        public int TransactionID { get; set; } = 0;
        public String? ProductName { get; set; }
        public String? ImageUrl { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int QuantityChanged { get; set; } = 1;
        public string? TransactionType { get; set; }

        public DateTime Date { get; set; }
        
    }
   
}
