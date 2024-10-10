using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Microwave : Appliance
    {
        public char roomType;
        double capacity;
        public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, double price, double capacity, char roomType) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.roomType = roomType;
            this.capacity = capacity;
        }

        public override string ToString()
        {


            return $"Item Number:{itemNumber + Environment.NewLine} Brand:{brand + Environment.NewLine} Quantity:{quantity + Environment.NewLine} Wattage:{wattage + Environment.NewLine} Color:{color.Trim() + Environment.NewLine} Price:{price + Environment.NewLine} capacity:{capacity + Environment.NewLine} room Type:{roomType + Environment.NewLine}";
        }

        public override string formatforFile()
        {
            return $"{itemNumber};{brand};{quantity};{wattage};{color};{price};{capacity};{roomType}";
        }
    }
}