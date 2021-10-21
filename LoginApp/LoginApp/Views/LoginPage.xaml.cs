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

            // Xamarin.Essentials.SecureStorage.Remove("user/saved");


        }

        protected override async void OnAppearing()
        {
            User user = new User();


            user = await service.LoginAutomatic();
            if (user == null)
            {
                //não tem conta salva
            }
            else
            {
                AutomaticLogin(user);
            }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            LoginInPage();

        }

        public async void AutomaticLogin(User user)
        {
            string r = await service.Login(user.Password, user.Email);


            if (r == "Sucessful")
            {
                MenuManager.currentuser = user;
                App.Current.MainPage = new NavigationPage(new AccountsPage()) { BarBackgroundColor = Color.FromHex("#6503A6") };

            }
            else if (r == "passwordworong")
            {
                await DisplayAlert("Erro", "Sua Senha foi Alterada e sua conta Deslogada!", "Ok");
            }

        }



        public async void LoginInPage()
        {
            string r = await service.Login(Password.Text, Email.Text);


            if (r == "Sucessful")
            {
                await DisplayAlert("LOGIN", "Logado com sucesso", "OK");
                User user = new User();
                user = await service.GetThisUser(Email.Text, Password.Text);



                if (LembrarUser.IsChecked)
                {

                    service.SaveUser(user);

                }





                MenuManager.currentuser = user;
                App.Current.MainPage = new NavigationPage(new AccountsPage()) { BarBackgroundColor = Color.FromHex("#6503A6") };

            }
            else if (r == "passwordworong")
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
            NavigationPage page = new NavigationPage(new RegisterPage()) { BarBackgroundColor = Color.FromHex("#6503A6") };


            await Navigation.PushModalAsync(page);


        }



    }
}