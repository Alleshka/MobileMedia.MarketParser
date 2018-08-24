using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileMedia.MarketParser.Model
{
    public class AppInfo
    {
        public String AppName { get; set; }
        public String PackageName { get; set; }
        public String IconUrl { get; set; }
        public double AveregeRate { get; set; }
        public String RateCount { get; set; }
        public String InstallCount { get; set; }
        public String Description { get; set; }
        public String NewInfo { get; set; }
        public String DevEmail { get; set; }
        public String Price { get; set; }
        public String MicroPrice { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<String> Images { get; set; }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();

            message.Append($"Name: {AppName} \n");
            message.Append($"Package: {PackageName} \n");
            message.Append($"Icon: {IconUrl} \n");
            message.Append($"Rate: {AveregeRate} \n");
            message.Append($"RateCount: {RateCount} \n");
            message.Append($"Installs: {InstallCount} \n");
            message.Append($"Description: {Description} \n\n");
            message.Append($"New: {NewInfo} \n\n");
            message.Append($"Dev: {DevEmail} \n");
            message.Append($"Price: {Price} \n");
            message.Append($"MicroPrice: {MicroPrice} \n");
            message.Append($"Updated: {LastUpdate.ToShortDateString()} \n");

            return message.ToString();
        }
    }
}
