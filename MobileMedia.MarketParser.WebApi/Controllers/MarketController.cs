using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MobileMedia.MarketParser.Model;
using MobileMedia.MarketParser.Parser;

namespace MobileMedia.MarketParser.WebApi.Controllers
{
    public class MarketController : ApiController
    {
        private IMarketParser market;

        public MarketController()
        {
            market = new XPathRuAppParser();
        }

        [HttpGet]
        [Route("api/app")]
        public AppInfo GetDefaultInfo()
        {
            return market.Parse("com.perm.kate_new_6");
        }

        [HttpPost]
        [Route("api/app")]
        public AppInfo GetAppInfo([FromBody]String packageName)
        {
            return market.Parse(packageName);
        }

        [HttpPost]
        [Route("api/apps")]
        public IEnumerable<AppInfo> GetListInfo([FromBody]IEnumerable<String> packages)
        {
            List<AppInfo> list = new List<AppInfo>();
            foreach (var package in packages)
            {
                try
                {
                    list.Add(market.Parse(package));
                }
                catch (Exception)
                {

                }
            }
            return list;
        }
    }
}
