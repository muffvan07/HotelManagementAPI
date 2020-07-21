using HotelManagement.Entities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BL
{
    public class UserBL
    {
        public List<UserVM> GetUsers()
        {
            List<UserVM> userList = new List<UserVM>();
            userList.Add(new UserVM()
            {
                ID = 1,
                UserName = "Mufaddal",
                Password = "killbill"
            });
            userList.Add(new UserVM()
            {
                ID = 102,
                UserName = "Emma",
                Password = "killbill"
            });
            return userList;
        }
    }
}
