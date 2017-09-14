using System; using System.Collections.Generic; using System.Linq; using System.Text; using System.Threading.Tasks; using Xamarin.Forms;  namespace MyApp.Std {
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();

    }      private async void ViewCurrentRide_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new ViewCurrentRide());     }

    private async void ViewAccountBalance_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new ViewAccountBalance());     }      private async void TopUpAccount_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new TopUpAccount());     }      private async void ViewMyRides_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new ViewMyRides());     }      private async void ViewGeneral_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new ViewGeneral());     }    } } 