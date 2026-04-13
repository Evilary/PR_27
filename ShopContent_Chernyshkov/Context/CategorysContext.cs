using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ShopContent_Chernyshkov.Modell;

namespace ShopContent_Chernyshkov.Context
{
    public class CategorysContext : Categorys
    {
        public static ObservableCollection<CategorysContext> AllCategorys()
        {

            ObservableCollection<CategorysContext> allCategorys = new ObservableCollection<CategorysContext>();
            SqlConnection connection;
            SqlDataReader dataCategorys = Connection.Query("SELECT * FROM [dbo].[Categorys]", out connection);
            while (dataCategorys.Read())
            {
                allCategorys.Add(new CategorysContext()
                {
                    Id = dataCategorys.GetInt32(0),
                    Name = dataCategorys.GetString(1),
                });
            }
            connection.CloseConnection(connection);

            return allCategorys;
        }
    }
}
