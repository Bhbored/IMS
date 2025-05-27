using IMS.MVVM.Model;
using IMS.MVVM.View;
using IMS.MVVM.ViewModel;

namespace IMS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();      
                if (!db.Products.Any())
                {
                    foreach (var product in HomeViewModel.Instance.CurrentInventory)
                    {
                        db.Products.Add(product);
                    }
                    db.SaveChanges();
                }
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new HomePage()));
        }
    }
}
