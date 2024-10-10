using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    internal class Dishwasher : Appliance
    {
        string feature;
        public string soundRating;

        public Dishwasher(long itemNumber, string brand, int quantity, double wattage, string color, double price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.feature = feature;
            this.soundRating = soundRating;

        }

        public override string ToString()
        {
            return $"Item Number:{itemNumber + Environment.NewLine} Brand:{brand + Environment.NewLine} Quantity:{quantity + Environment.NewLine} Wattage:{wattage + Environment.NewLine} Color:{color.Trim() + Environment.NewLine} Price:{price + Environment.NewLine} feature:{feature + Environment.NewLine} battery sound Rating:{soundRating + Environment.NewLine}";
        }

        public override string formatforFile()
        {
            return $"{itemNumber};{brand};{quantity};{wattage};{color};{price};{feature};{soundRating}";
        }

    }
}