using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Vacuum : Appliance
    {
        public int batteryWattage;
        public string grade;
        string stringWattage;
        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, double price, int batteryWattage, string grade) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.batteryWattage = batteryWattage;
            this.grade = grade;
        }

        public override string ToString()
        {

            if (batteryWattage == 18)
            {
                stringWattage = "low";
            }
            else if (batteryWattage == 24)
            {
                stringWattage = "high";
            }

            return $"Item Number:{itemNumber + Environment.NewLine} Brand:{brand + Environment.NewLine} Quantity:{quantity + Environment.NewLine} Wattage:{wattage + Environment.NewLine} Color:{color.Trim() + Environment.NewLine} Price:{price + Environment.NewLine} grade:{grade + Environment.NewLine} battery wattage:{stringWattage + Environment.NewLine}";
        }

        public override string formatforFile()
        {
            return $"{itemNumber};{brand};{quantity};{wattage};{color};{price};{grade};{batteryWattage}";
        }
    }
}