using LoginApp.Services;
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
    public partial class RegisterPage : ContentPage
    {
        public LoginService service = new LoginService();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string r = await service.Register(Password.Text, Email.Text, Name.Text);

            if(r == "existaccount")
            {
                await DisplayAlert("Erro", "Essa conta já Existe", "Ok");
            }else if (r == "Sucess")
            {
                await DisplayAlert("Pronto", "Conta feita com exito " + Name.Text,"Ok");
                App.Current.MainPage = new LoginPage();
            }
        }
    }
}