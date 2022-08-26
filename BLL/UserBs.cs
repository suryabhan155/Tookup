using BOL;
using BOL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TookUp.BOL.ViewModels.CommonModels;

namespace BLL
{
    public class UserBs
    {
        private UserDb user_obj;
        public UserBs()
        {
            user_obj = new UserDb();
        }
        public IEnumerable<User> GetAll()
        {
            return user_obj.GetAll();
        }

        public User GetById(int id)
        {
            return user_obj.GetById(id);
        }
        public ResponseModel Insert(User user)
        {
            return user_obj.Insert(user);
        }
        public void Update(User user)
        {
            user_obj.Update(user);

        }
        public void Delete(int id)
        {
            user_obj.Delete(id);
        }
        public ResponseModel SendMail(OTP otp)
        {
            return user_obj.SendMail(otp);
        }
        public ResponseModel SendSMS(OTP otp)
        {
            return user_obj.SendSMS(otp);
        }
        public ResponseModel GetUserInfo(int id)
        {
            return user_obj.GetUserById(id);
        }
        public ResponseModel GetUserList()
        {
            return user_obj.GetUserList();
        }
    }
}
