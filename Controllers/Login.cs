using Microsoft.AspNetCore.Components;

namespace StepsWebApp.Controllers
{
  
    public class LoginController
    {

        string dpassword { get; set; }
        string dusername { get; set; }

         public bool login(string email,string pass)
          {
             

            Models.User u1 = new Models.User();
            Models.StepsContext db = new Models.StepsContext();

            //u1.Email = username;
            //u1.Password = password;
            //db.Users.Add(u1);
            //db.SaveChanges();
            u1 = db.Users.First(x => x.Email == email);

            if (u1 != null)
            {
                if (u1.Password == pass)
                {
                    Models.User.theUser = u1;

                    return true;

                }
            }
            return false;

        }
    }
}
