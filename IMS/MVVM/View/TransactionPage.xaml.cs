using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using IMS.MVVM.Model;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IMS.MVVM.View
{
    public partial class TransactionPage : ContentPage
    {
        public ObservableCollection<Transaction> TransactionList { get; set; } = new();

        public TransactionPage()
        {
            InitializeComponent();
            LoadTransactions();
            BindingContext = this;
        }

        private void LoadTransactions()
        {
            using (var db = new AppDbContext())
            {
                var list = db.Transactions.ToList();
                TransactionList.Clear();
                foreach (var tx in list)
                    TransactionList.Add(tx);
            }
        }

        private async void OnDeleteTransaction(object sender, EventArgs e)
        {
            var transaction = (sender as Button)?.CommandParameter as Transaction;
            if (transaction == null) return;

            bool confirm = await DisplayAlert("Delete Transaction",
                $"Are you sure you want to delete Transaction #{transaction.TransactionID}?", "Yes", "No");

            if (!confirm) return;

            using (var db = new AppDbContext())
            {
                var toDelete = db.Transactions.FirstOrDefault(t => t.TransactionID == transaction.TransactionID);
                if (toDelete != null)
                {
                    db.Transactions.Remove(toDelete);
                    db.SaveChanges();
                }
            }

            TransactionList.Remove(transaction);
            try
            {
                await Toast.Make("Transaction deleted", ToastDuration.Short).Show();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Notice", "Transaction deleted.", "OK");
            }
        }

        private async void GoHome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        private async void GoToInventory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventoryPage());
        }
    }
}
