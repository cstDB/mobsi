using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ViewAccountBalance : ContentPage
  {
    public ViewAccountBalance()
    {
      InitializeComponent();
    }

    private async void TopUpAccount_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new TopUpAccount());     }
    

  }
}