using System;
using System.Collections.ObjectModel;
using System.Linq;
using MySqlConnector;
using ShopContent_Chernyshkov.Classes;
using ShopContent_Chernyshkov.Modell;

namespace ShopContent_Chernyshkov.Context
{
    public class ItemsContext : Items
    {
        public ItemsContext(bool save = false)
        {
            if (save) Save(true);
            Category = new Categorys();
        }

        public static ObservableCollection<ItemsContext> AllItems()
        {
            ObservableCollection<ItemsContext> allItems = new ObservableCollection<ItemsContext>();
            ObservableCollection<CategorysContext> allCategorys = CategorysContext.AllCategorys();
            MySqlConnection connection;
            MySqlDataReader dataItems = Connection.Query("SELECT * FROM Items", out connection);
            while (dataItems.Read())
            {
                allItems.Add(new ItemsContext()
                {
                    Id = dataItems.GetInt32(0),
                    Name = dataItems.GetString(1),
                    Price = dataItems.GetDouble(2),
                    Description = dataItems.GetString(3),
                    Category = dataItems.IsDBNull(4) ? null : allCategorys.FirstOrDefault(x => x.Id == dataItems.GetInt32(4))
                });
            }
            Connection.CloseConnection(connection);
            return allItems;
        }

        public void Save(bool New = false)
        {
            MySqlConnection connection;
            if (New)
            {
                string sql = "INSERT INTO Items (Name, Price, Description) " +
                             $"VALUES ('{this.Name}', {this.Price}, '{this.Description}'); " +
                             "SELECT LAST_INSERT_ID();";
                MySqlDataReader dataItems = Connection.Query(sql, out connection);
                dataItems.Read();
                this.Id = dataItems.GetInt32(0);
            }
            else
            {
                string sql = "UPDATE Items SET " +
                             $"Name = '{this.Name}', " +
                             $"Price = {this.Price}, " +
                             $"Description = '{this.Description}', " +
                             $"IdCategory = {this.Category?.Id ?? 0} " +
                             $"WHERE Id = {this.Id}";
                Connection.Query(sql, out connection);
            }
            Connection.CloseConnection(connection);
            MainWindow.init.frame.Navigate(MainWindow.init.Main);
        }

        public void Delete()
        {
            MySqlConnection connection;
            string sql = $"DELETE FROM Items WHERE Id = {this.Id}";
            Connection.Query(sql, out connection);
            Connection.CloseConnection(connection);
        }

        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new View.Add(this));
                });
            }
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (this.Category != null)
                    {
                        Category = CategorysContext.AllCategorys()
                            .FirstOrDefault(x => x.Id == this.Category.Id);
                    }
                    Save();
                });
            }
        }

        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Delete();
                    (MainWindow.init.Main.DataContext as ViewModell.VMItems).Items.Remove(this);
                });
            }
        }
    }
}