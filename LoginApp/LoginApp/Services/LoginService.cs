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
                    if (password == user[i].password)
                    {
                        //senha correta!

                        result = "Sucessful";

                        break;
                      
                    }



                    //senha incorreta!
                    result =  "passwordworong";
                    return result;

                }
            }
            catch
            {

                result = "nothingdata";
            }

            return result;
        }

        public async Task<string> Register(string password,string Email)
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




            user.password = password;
            user.email = Email;

            for (int i = 0; i < userlist.Count; i++)
            {
                if(userlist[i].email == user.email)
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




    }
}
