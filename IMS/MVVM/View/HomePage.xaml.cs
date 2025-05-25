using IMS.MVVM.Model;
using IMS.MVVM.ViewModel;
using System.Windows.Input;

namespace IMS.MVVM.View;

public partial class HomePage : ContentPage
{

	
    
    public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomeViewModel();
       
    }
    private async void OnOrdersClicked(object sender, EventArgs e)
    {
        
        
    }


}
