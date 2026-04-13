using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShopContent_Chernyshkov.Modell
{
    public class Items : INotifyPropertyChanged
    {

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");

            }
        }

        private double price;
        public double Price
        {
            get { return Price; }
            set
            {
                Price = value;
                OnPropertyChanged("Price");

            }
        }

        private string description;
        public string Description
        {
            get { return Description; }
            set
            {
                Description = value;
                OnPropertyChanged("Description");

            }
        }

        private Categorys category;
        public Categorys Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");

            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));  
        }
    }
}
