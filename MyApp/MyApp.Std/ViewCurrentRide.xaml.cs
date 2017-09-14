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
  public partial class ViewCurrentRide : ContentPage
  {
    public ViewCurrentRide()
    {
      InitializeComponent();
    }


    private async void CorrectRide_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new CorrectRide());     }

    private async void UpdateView1_Clicked(object sender, EventArgs e)
    {       await Navigation.PushAsync(new UpdateView1());     }
    
  }
}