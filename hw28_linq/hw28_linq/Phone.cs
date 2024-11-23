using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw28_linq
{
    public class Phone
    {
        public string ModelName { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public Phone() 
        {
            ModelName = string.Empty;
            Manufacturer = string.Empty;
            ReleaseDate = new DateOnly();
        }
        public Phone(string modelName, string manufacturer, int price, DateOnly releaseDate) 
        {
            ModelName = modelName;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseDate = releaseDate;
        }
        public override string ToString()
        {
            return $"Model Name: {ModelName}, \nManufacturer: {Manufacturer}, \nPrice: {Price}$, \nReleaseDate: {ReleaseDate}\n";
        }
    }
}
