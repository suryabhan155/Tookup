using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TookUp.BOL.Utils;
using UI.Models;

namespace UI.Token_RelatedRepository
{
    public class UserMasterRepository : IDisposable
    {
        //This method is used to check and validate the user credentials
        public static UserDetails ValidateUser(string username, string password)
        {
            UserDetails response = null;
            try
            {
                password = Encryption.EncryptString(password);
                using (TookupDBEntities db = new TookupDBEntities())
                {
                    var user = db.Users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);
                    if (user != null)
                    {
                        response = new UserDetails();
                        response.UserId = user.UserID;
                        response.DisplayName = $"{user.Firstname} {user.Lastname}";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public void Dispose()
        {
            TookupDBEntities db = new TookupDBEntities();
            db.Dispose();
        }
    }
}
