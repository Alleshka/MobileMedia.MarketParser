using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileMedia.MarketParser.Parser;

namespace MobileMedia.MarketParser.GUI.ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMarketParser marketParser = new XPathRuAppParser();

            Console.WriteLine(marketParser.Parse("com.tinder"));

            //Console.WriteLine(marketParser.Parse("https://play.google.com/store/apps/details?id=ru.sberbankmobile"));

            //Console.WriteLine(marketParser.Parse("https://play.google.com/store/apps/details?id=com.asus.ime"));

            //Console.WriteLine(marketParser.Parse("https://play.google.com/store/apps/details?id=com.mojang.minecraftpe"));

            //Console.WriteLine(marketParser.Parse("https://play.google.com/store/apps/details?id=com.hcg.cok.gp"));
        }
    }
}
