using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mission3Assignment
{
    internal class FoodItem
    {
        //declare attributes of a food item (name, category, quantity, expiration date)
        public string Name = "";
        public string Category = "";
        public int Quantity = 0;
        public DateTime ExpirationDate;
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }
    }
}
