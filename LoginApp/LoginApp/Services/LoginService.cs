using LoginApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Services
{
    public class LoginService
    {

      

        public async Task<string> Login(string password, string email)
        {
            string json = "";
            string result = "";  

            List<User> user = new List<User>();


            try
            {
                json = await Xamarin.Essentials.SecureStorage.GetAsync("user");



                user = JsonConvert.DeserializeObject<List<User>>(json);

                for (int i = 0; i < user.Count; i++)
                {
                    if (password == user[i].Password)
                    {
                        //senha correta!

                        result = "Sucessful";

                        return result;
                      
                    }

                }



                //senha incorreta!
                result = "passwordworong";
                return result;
            }
            catch
            {

                result = "nothingdata";
            }

            return result;
        }
      
        public async Task<string> Register(string password,string Email, string Nome)
        {
            //register
            string r = "";
            List<User> userlist = new List<User>();
            User user = new User();

            if (!string.IsNullOrEmpty(await Xamarin.Essentials.SecureStorage.GetAsync("user")))
            {
                string jsonlist = await Xamarin.Essentials.SecureStorage.GetAsync("user");
                userlist = JsonConvert.DeserializeObject<List<User>>(jsonlist);
            }
            else
            {

            }




            user.Password = password;
            user.Email = Email;
            user.Name = Nome;

            for (int i = 0; i < userlist.Count; i++)
            {
                if(userlist[i].Email == user.Email)
                {
                    //EMAIL JÁ EXISTE
                    r = "existaccount";
                    return r;

                }


            }


            userlist.Add(user);

            string jsonuser = JsonConvert.SerializeObject(userlist);


            await Xamarin.Essentials.SecureStorage.SetAsync("user", jsonuser);

            r = "Sucess";
            //REGISTRADO
            return r;
        }



        public async Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();

            string r = await Xamarin.Essentials.SecureStorage.GetAsync("user");

            users = JsonConvert.DeserializeObject<List<User>>(r);

            return  users;
        }


        public async Task<User> GetThisUser(string Email, string Password)
        {
            User user = new User();
            List<User> users = new List<User>();

            string r = await Xamarin.Essentials.SecureStorage.GetAsync("user");

            users = JsonConvert.DeserializeObject<List<User>>(r);

            for (int i = 0; i < users.Count; i++)
            {
                if (Password == users[i].Password)
                {
                    //senha correta!

                    user = users[i];

                    return user;

                }
            }

            return null;
        }


        public async void SaveUser(User user)
        {
            List<User> users = new List<User>();

            string r = await Xamarin.Essentials.SecureStorage.GetAsync("user/saved");

            if (string.IsNullOrEmpty(r))
            {
                users.Add(user);

                string response = JsonConvert.SerializeObject(users);

                await Xamarin.Essentials.SecureStorage.SetAsync("user/saved",response);

                return;
            }
            else
            {
                users =  JsonConvert.DeserializeObject<List<User>>(r);

                users.Add(user);
                return;

            }



        }

        public async Task<User> LoginAutomatic()
        {


            string response = await Xamarin.Essentials.SecureStorage.GetAsync("user/saved");

            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            else
            {
                User user = new User();
                List<User> users = new List<User>();
                users = JsonConvert.DeserializeObject<List<User>>(response);
                user = users[0];

                return user;
            }


        }
    }
}
