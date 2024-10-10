using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Appliance
    {
        public long itemNumber;
        public string brand;
        public int quantity;
        public double wattage;
        public string color;
        public double price;


        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, double price)
        {
            this.itemNumber = itemNumber;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.color = color;
            this.price = price;

        }

        public bool isAvailable()
        {
            if (quantity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void checkout()
        {
            if (isAvailable())
            {
                Console.WriteLine($"Your item {itemNumber}, {brand}, {color} has been checked out");
                Console.WriteLine(quantity);
                quantity--;
            }
            else
            {
                Console.WriteLine("this item is not available to be checked out.");
            }

        }


        public override string ToString()
        {
            //return base.ToString();
            return $"Item Number:{itemNumber + Environment.NewLine} Brand:{brand + Environment.NewLine} Quantity:{quantity + Environment.NewLine} Wattage:{wattage + Environment.NewLine} Color:{color.Trim() + Environment.NewLine} Price:{price + Environment.NewLine}";
        }


        public virtual string formatforFile()
        {
            return $"{itemNumber};{brand};{quantity};{wattage};{color};{price}";
        }

    }
}