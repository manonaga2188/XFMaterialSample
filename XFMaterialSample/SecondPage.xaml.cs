using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI;
using XF.Material.Forms.UI.Dialogs;

namespace XFMaterialSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            MaterialButton btn = new MaterialButton { 
            Text="Welcome"
            };
            btn.Clicked += Btn_Clicked;
            stContainer.Children.Add(btn);
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            ((MaterialButton)sender).Text = "Clicked 1 TIme";
        }

        private async void MaterialButton_Clicked_9(object sender, EventArgs e)
        {
            await MaterialDialog.Instance.AlertAsync(message:"date",
                                               title: "Alert Dialog",
                                               acknowledgementText: "Got It");
        }
    }
}