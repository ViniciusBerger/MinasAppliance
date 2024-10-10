using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Refrigerator : Appliance
    {
        public int numberofDoors;
        public int height;
        public int width;


        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, double price, int numberofDoors, int height, int width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.numberofDoors = numberofDoors;
            this.height = height;
            this.width = width;

        }

        public override string ToString()
        {
            return $"Item Number:{itemNumber + Environment.NewLine} Brand:{brand + Environment.NewLine} Quantity:{quantity + Environment.NewLine} Wattage:{wattage + Environment.NewLine} Color:{color.Trim() + Environment.NewLine} Price:{price + Environment.NewLine} height {height + Environment.NewLine} width: {width + Environment.NewLine}";
        }

        public override string formatforFile()
        {
            return $"{itemNumber};{brand};{quantity};{wattage};{color};{price};{numberofDoors};{height};{width}";
        }
    }
}