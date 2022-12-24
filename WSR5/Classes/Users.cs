using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSR5.Database;

namespace WSR5.Classes
{
    class Users
    {
        public static List<User> users = ClothesEntitys.GetEntitys().Users.ToList(); 
    }
}
