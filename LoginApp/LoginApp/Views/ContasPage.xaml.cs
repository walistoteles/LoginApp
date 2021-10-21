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
    public partial class ContasPage : ContentPage
    {
        public LoginService service = new LoginService();

        public ContasPage()
        {
            InitializeComponent();
            GetList();
        }


        public async void GetList()
        {
            ListaDeContas.ItemsSource = await service.GetUsers();

        }

    }
}