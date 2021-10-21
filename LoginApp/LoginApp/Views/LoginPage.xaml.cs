using LoginApp.Models;
using LoginApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginService service = new LoginService();


        public LoginPage()
        {
            InitializeComponent();

        }

        async void Button_Clicked(object sender, EventArgs e)
        {

            {

                {

                        break;
                    }

            {
                //sem dados
                DisplayAlert("Error", "Dados não foram Encontrados", "Ok");

                json = "nothing yet";
            }




        }


        async void Button_Clicked_1(object sender, EventArgs e)
        {

            {
            }
          

        }
    }
}