using HotelManagement.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagementApi.Models
{
    public class UserValidation
    {
        public static bool Login(string username, string password)
        {
            UserBL userBL = new UserBL();
            var UserLists = userBL.GetUsers();
            return UserLists.Any(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
    }
}