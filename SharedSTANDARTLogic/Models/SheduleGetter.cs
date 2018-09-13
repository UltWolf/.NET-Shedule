using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using Newtonsoft.Json;
using SharedSTANDARTLogic.Models.Resource;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedSTANDARTLogic.Models
{
    public class SheduleGetter
    {
        
        private readonly string UrlShedule = @" http://195.95.232.162:8082/cgi-bin/timetable.cgi" ;
        private ExtenWebClient wc = new ExtenWebClient();
     
        public Dictionary<int, List<Shedule>> GetShedule(string faculty, string teacher, string group, string sdate,string edate){
  
            string request = "faculty=" +faculty+ "&teacher=" + teacher + " &group=" + group + "&sdate=" + sdate + "&edate=" + edate + "&n=700";
            Dictionary<int, List<Shedule>> SheduleDictionary = new Dictionary<int, List<Shedule>>();
            List<Shedule> shedules = new List<Shedule>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            wc.Encoding = Encoding.GetEncoding(1251);
            string htmlresult = wc.UploadString(UrlShedule,request);
            IHtmlDocument IHD = new AngleSharp.Parser.Html.HtmlParser().Parse(htmlresult);
            var tables =IHD.QuerySelectorAll("table");

            for (var a = 0; a < tables.Length; a++) {
                var trs = tables[a].Children[0].Children ;
                foreach (var tr in trs)
                {

                    string time = tr.Children[1].InnerHtml.Replace("<br>", "-");
                    string subject = tr.Children[2].InnerHtml;
                    shedules.Add(new Shedule() { time = time, subject = subject });
                }
                SheduleDictionary.Add(a,shedules);
                shedules = new List<Shedule>()  ;
                    }
 
            return SheduleDictionary;
        }  


        public   SheduleRequest GetGroups(string requestName){
            WebRequest WRPlayer = WebRequest.Create(UrlShedule + "?n=701&lev=142&faculty=0&query= "+requestName);
            WRPlayer.Method = "GET";
            WRPlayer.ContentType = " text / html; charset = windows - 1251";
          
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var SheduleResponse = new SheduleRequest();
            try
            {
                
                using (WebResponse response = WRPlayer.GetResponse())
                {

                    using (Stream stream = response.GetResponseStream())
                    {

                        using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(1251)))
                        {
                            SheduleResponse = JsonConvert.DeserializeObject<SheduleRequest>(reader.ReadToEnd());
                        }

                    }
                }
            }
            catch (JsonReaderException)
            {
                return null;
            }

            return SheduleResponse ;


    }
    }
    public static class ExtensionIEnumerable
    {
        public static List<IElement> GetElementsFromRange(this IHtmlCollection<IElement> collection, int beginRange, int endRange)
        {

            List<IElement> newCollection = new List<IElement>();
            for (; beginRange < endRange; beginRange++)
            {
                newCollection.Add(collection[beginRange]);
            }
            return newCollection;

        }
        public static List<IElement> GetElementsFromRange(this IHtmlCollection<IElement> collection, int beginRange)
        {
            int endRange = collection.Length - 1;
            List<IElement> newCollection = new List<IElement>();
            for (; beginRange <= endRange; beginRange++)
            {
                newCollection.Add(collection[beginRange]);
            }
            return newCollection;

        }


    }
}