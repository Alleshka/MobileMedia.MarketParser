using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileMedia.MarketParser.Model;

namespace MobileMedia.MarketParser.Parser
{
    public interface IMarketParser
    {
        AppInfo Parse(String input);
    }
}
