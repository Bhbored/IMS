using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using IMS.MVVM.Model;

namespace IMS.MVVM.View;

public partial class EditProductPage : ContentPage
{
    private Product product;

    public EditProductPage(Product p)
    {
        InitializeComponent();
        product = p;

        nameEntry.Text = product.Name;
        stockEntry.Text = product.Stock.ToString();
        priceEntry.Text = product.Price.ToString("F2");
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(stockEntry.Text, out int stock) || !decimal.TryParse(priceEntry.Text, out decimal price))
        {
            await DisplayAlert("Invalid input", "Please enter valid stock and price.", "OK");
            return;
        }

        using (var db = new AppDbContext())
        {
            var p = db.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            if (p != null)
            {
                p.Name = nameEntry.Text;
                p.Stock = stock;
                p.Price = price;
                db.SaveChanges();
            }
        }

        product.Name = nameEntry.Text;
        product.Stock = stock;
        product.Price = price;


        await DisplayAlert("Product Updated", $"{product.Name} has been successfully updated.", "OK");
        await Navigation.PopModalAsync();
    }


    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
