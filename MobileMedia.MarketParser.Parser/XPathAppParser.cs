using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MobileMedia.MarketParser.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace MobileMedia.MarketParser.Parser
{
    public class XPathRuAppParser : IMarketParser
    {
        private String appPackage;

        public AppInfo Parse(string input)
        {
            String url = GetAppLink(input);

            HtmlDocument page = GetAppPage(url);

            AppInfo appInfo = new AppInfo()
            {
                AppName = GetAppName(page),
                PackageName = GetPackageName(page),
                IconUrl = GetIconUrl(page),
                AveregeRate = GetAverageRate(page),
                InstallCount = GetInstallCount(page),
                Description = GetDescription(page),
                NewInfo = GetNewFeatures(page),
                DevEmail = GetDevMail(page),
                Price = GetAppPrice(page),
                MicroPrice = GetMicroAppPrice(page),
                LastUpdate = GetLastUpdate(page),
                Images = GetImages(page),
                RateCount = GetRateCount(page)
            };

            return appInfo;
        }

        private bool IsLink(String input)
        {
            try
            {
                Uri uri = new Uri(input);
                return true;
            }
            catch
            {
                return false;
            }

            // return input.Contains("play.google.com/store");
        }

        private String GetAppLink(String input)
        {
            String url;

            if (IsLink(input))
            {
                this.appPackage = GetAppPackage(input);
                url = input;
            }
            else
            {
                this.appPackage = input;
                url = $"https://play.google.com/store/apps/details?id={input}";
            }

            return url;
        }

        private HtmlDocument GetAppPage(String url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "ru,en;q=0.9");
            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(reader.ReadToEnd());
                    return document;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                response.Close();
            }
        }

        private String GetAppName(HtmlDocument document)
        {
            return document.DocumentNode.SelectSingleNode("//*[@id=\"fcxH9b\"]//div[4]//c-wiz//div//div[2]//div//div[1]//div//c-wiz[1]//c-wiz[1]//div//div[2]//div//div[1]//c-wiz[1]//h1//span").InnerText;
        }

        private String GetPackageName(HtmlDocument document)
        {
            return this.appPackage;
        }

        private String GetIconUrl(HtmlDocument document)
        {
            return document.DocumentNode.SelectSingleNode("//div[@class=\"dQrBL\"]").SelectSingleNode(".//img").GetAttributeValue("src", "-");
        }
        
        private double GetAverageRate(HtmlDocument document)
        {
            String rate = document.DocumentNode.SelectSingleNode("//div[@class=\"BHMmbe\"]").InnerText;
            return Convert.ToDouble(rate.Replace(".", ","));
        }

        private String GetInstallCount(HtmlDocument document)
        {
            var infoBlock = document.DocumentNode.SelectSingleNode("//div[@class=\"xyOfqd\"]");

            // TODO: Отчаянный вариант
            var spanList = infoBlock.SelectNodes(".//div[@class=\"BgcNfc\"]").ToList().Find(x=>x.InnerText== "Количество установок");
            var cout = spanList.ParentNode.SelectNodes(".//span[@class=\"htlgb\"]").Reverse().First().InnerText;
            return cout;
        }

        private String GetDescription(HtmlDocument document)
        {
            return document.DocumentNode.SelectSingleNode("//div[@jsname=\"sngebd\"]").InnerHtml;
        }

        private String GetNewFeatures(HtmlDocument document)
        {
            var text = document.DocumentNode.SelectNodes("//div[@class=\"DWPxHb\"]");
            if (text.Count > 1)
            {
                return text[1].FirstChild.InnerHtml;
            }
            else return String.Empty;
        }

        private String GetDevMail(HtmlDocument document)
        {
            var aboutProgram = document.DocumentNode.SelectNodes("//div[@class=\"hAyfc\"]").Reverse().ToList()[0];
            var developDiv = aboutProgram.ChildNodes[1];
            var links = developDiv.SelectNodes(".//a").ToList().Find(x=>x.GetAttributeValue("href", "-").Contains("mailto"));
            return links.InnerText;

        }

        private String GetAppPrice(HtmlDocument document)
        {
            return String.Empty;
        }

        private String GetMicroAppPrice(HtmlDocument document)
        {
            var infoBlock = document.DocumentNode.SelectSingleNode("//div[@class=\"xyOfqd\"]");

            var spanList = infoBlock.SelectNodes(".//div[@class=\"BgcNfc\"]").ToList().Find(x => x.InnerText == "Платный контент");
            if (spanList != null)
            {
                var cout = spanList.ParentNode.SelectNodes(".//span[@class=\"htlgb\"]").Reverse().First().InnerText;
                return cout;
            }
            else return String.Empty;
        }

        private DateTime GetLastUpdate(HtmlDocument document)
        {
            DateTime time = new DateTime();
            // TODO: Тупейший вариант
            var fasfpasf = document.DocumentNode.SelectNodes("//span[@class=\"htlgb\"]").Where(x => x.ChildNodes.Count == 1).ToList().Find(x => DateTime.TryParse(x.InnerText, out time));
            return time;
        }

        private String GetRateCount(HtmlDocument document)
        {
            var rateInfo = document.DocumentNode.SelectSingleNode("//span[@class=\"EymY4b\"]").ChildNodes[2].InnerText;

            return rateInfo;
        }

        private List<String> GetImages(HtmlDocument document)
        {
                List<String> images = new List<string>();

                var imgBlock = document.DocumentNode.SelectSingleNode("//div[@jsname=\"CmYpTb\"]");
                var blockImages = imgBlock?.SelectNodes(".//img[@itemprop=\"image\"]");

                foreach (var img in blockImages)
                {
                    images.Add(img?.GetAttributeValue("src", "-"));
                }


                return images;
        }

        private String GetAppPackage(String url)
        {
            var uri = new Uri(url);
            var queryString = string.Join(string.Empty, url.Split('?').Skip(1));
            var collection = System.Web.HttpUtility.ParseQueryString(queryString);
            return collection[0];
        }
    }
}
