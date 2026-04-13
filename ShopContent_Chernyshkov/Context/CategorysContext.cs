using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ShopContent_Chernyshkov.Modell;
using MySqlConnector;
using ShopContent_Chernyshkov.Classes;

namespace ShopContent_Chernyshkov.Context
{
    public class CategorysContext : Categorys
    {
        public static ObservableCollection<CategorysContext> AllCategorys()
        {

            ObservableCollection<CategorysContext> allCategorys = new ObservableCollection<CategorysContext>();
            MySqlConnection connection;
            MySqlDataReader dataCategorys = Connection.Query("SELECT * FROM Categorys", out connection);
            while (dataCategorys.Read())
            {
                allCategorys.Add(new CategorysContext()
                {
                    Id = dataCategorys.GetInt32(0),
                    Name = dataCategorys.GetString(1),
                });
            }
            Connection.CloseConnection(connection);  

            return allCategorys;
        }
    }
}
