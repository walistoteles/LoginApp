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
            string r = await service.Login(Password.Text, Email.Text);

            if(r == "Sucessful")
            {
                // logado
                DisplayAlert("Login", "Login Feito com Sucesso", "Ok");
            }

            if (r == "passwordworong")
            {
                // senha errada
                DisplayAlert("Error", "Dados Incorretos", "Ok");

            }

            if (r== "nothingdata")
            {
                //sem dados
                DisplayAlert("Error", "Dados não foram Encontrados", "Ok");

            }
        }


        async void Button_Clicked_1(object sender, EventArgs e)
        {
            string r = await service.Register(Password.Text, Email.Text);


            if(r == "Sucess")
            {
                DisplayAlert("Registrado", "Conta Registrada", "Ok");
            }

            if (r == "existaccount")
            {
                DisplayAlert("Error", "Conta Já Existe", "Ok");

            }
        }
    }
}