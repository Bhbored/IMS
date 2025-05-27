using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using IMS.MVVM.Model;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace IMS.MVVM.View
{
    public partial class InventoryPage : ContentPage
    {
        public ObservableCollection<Product> InventoryList { get; set; } = new();

        public InventoryPage()
        {
            InitializeComponent();
            LoadInventory();
            BindingContext = this;
        }

        private void LoadInventory()
        {
            using (var db = new AppDbContext())
            {
                var products = db.Products.ToList();
                InventoryList.Clear();
                foreach (var product in products)
                {
                    InventoryList.Add(product);
                }
            }
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            if ((sender as Button)?.CommandParameter is not Product product)
                return;
            

            await Navigation.PushModalAsync(new EditProductPage(product));
            



        }

        private async void GoHome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        private async void GoTransactions(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransactionPage());
        }
    }
}
