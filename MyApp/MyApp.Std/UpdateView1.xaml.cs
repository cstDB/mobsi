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
  public partial class UpdateView1 : ContentPage
  {
    public UpdateView1()
    {
      InitializeComponent();
    }


    private async void CorrectRide_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new CorrectRide());     }

    private async void UpdateView2_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new UpdateView2());     }
  }
}