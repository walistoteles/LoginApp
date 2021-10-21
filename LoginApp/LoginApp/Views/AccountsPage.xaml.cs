using LoginApp.Models;
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
    public partial class AccountsPage : ContentPage
    {
        public List<User> users = new List<User>();
        public LoginService service = new LoginService();

        public AccountsPage()
        {
            InitializeComponent();
            GetUsers();
        }


        public async void GetUsers()
        {
            users = await service.GetUsers();
           

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            string Message = "Seja Bem Vindo";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}