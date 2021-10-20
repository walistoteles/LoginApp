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

        public LoginPage()
        {
            InitializeComponent();

        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            string json = "";

            List<User> user = new List<User>();


            try
            {
                json = await Xamarin.Essentials.SecureStorage.GetAsync("user");



                user = JsonConvert.DeserializeObject<List<User>>(json);

                for (int i = 0; i < user.Count; i++)
                {
                    if(Password.Text == user[i].password)
                    {
                        //senha correta!
                        await DisplayAlert("Login Feito", "Login Feito com Sucesso", "OK");

                        break;
                    }

                    //senha incorreta!
                    await DisplayAlert("Error", "Senha Incorreta", "OK");
                    break;
                    
                }
            }
            catch 
            {

                json = "nothing yet";
            }




        }


        async void Button_Clicked_1(object sender, EventArgs e)
        {
            //register
            List<User> userlist = new List<User>();
            User user = new User();

            if(string.IsNullOrEmpty(await Xamarin.Essentials.SecureStorage.GetAsync("user")))
            {
                // VAZIO
            }
            else
            {
                string jsonlist = await Xamarin.Essentials.SecureStorage.GetAsync("user");
                userlist = JsonConvert.DeserializeObject<List<User>>(jsonlist);
            }
          



            user.password = Password.Text;
            user.email = Email.Text;


            userlist.Add(user);

            string jsonuser = JsonConvert.SerializeObject(userlist);

            await Xamarin.Essentials.SecureStorage.SetAsync("user", jsonuser);
        }
    }
}