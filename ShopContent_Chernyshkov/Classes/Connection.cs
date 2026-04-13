using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShopContent_Chernyshkov.Classes
{
    public class Connection
    {
        private static string ConnectionConnection = "server=127.0.0.1;uid=root;pwd=;database=;";
        public static MySqlServerVersion Version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
