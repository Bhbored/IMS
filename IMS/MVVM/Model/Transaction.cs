using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IMS.MVVM.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? PaymentMethod { get; set; } 
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; } 
        public ObservableCollection<Orders>? OrderItems { get; set; }
        public int OrderCount { get; set; }
        public string? CustomerName { get; set; }
        public string? Notes { get; set; }
    }
}
