using BankDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankBLL.Bl
{
    public class UserDataBl
    {
        private BankEmulatorContext db;
        public UserDataBl(BankEmulatorContext context)
        {
            db = context;
        }

        public UserData Login(string mail, string password)
        {
            UserData? data = null;
            var accessdata = db.UserAccessData.FirstOrDefault(x => x.Mail == mail && x.Password == password);
            if (accessdata == null) { data = db.UserData.FirstOrDefault(x => x.Id == accessdata.UserId); }
            return data;
        }

        public UserData Register(UserData user)
        {
            if (user is not null)
            {
                db.UserData.Add(user);
                
                db.SaveChanges();
            }
            return user;
        }

        



    }
}
