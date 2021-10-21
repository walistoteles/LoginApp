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

             //Xamarin.Essentials.SecureStorage.Remove("user");

        }

        async void Button_Clicked(object sender, EventArgs e)
        {

            string r = await service.Login(Password.Text, Email.Text);


            if(r== "Sucessful")
            {
               await DisplayAlert("LOGIN", "Logado com sucesso", "OK");
                App.Current.MainPage = new  AccountsPage();

            }else if(r == "passwordworong")
            {
                await DisplayAlert("ERROR", "Dados incorretos", "OK");

            }

            if (r == "nothingdata")
            {
                await DisplayAlert("ERROR", "Dados não encontrados", "OK");

            }

        }


        async void Button_Clicked_1(object sender, EventArgs e)
        {
            NavigationPage page = new NavigationPage(new RegisterPage());


            await Navigation.PushAsync(page);
          

        }
        

       
    }
}