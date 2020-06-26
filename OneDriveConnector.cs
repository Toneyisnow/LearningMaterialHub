using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterialHub
{
    public class OneDriveConnector
    {
        private static Uri baseAddress = new Uri(@"https://toneysui-my.sharepoint.com/personal/toneyisnow_toneysui_onmicrosoft_com/");
        private string bodyStringFile = @".\createLinkTemplate.json";
        private static string listIdEncoded = @"%27%7BA4440530%2DD35E%2D4F78%2DB0C7%2D713F97907321%7D%27";

        private static Dictionary<string, string> materialIdMapping = new Dictionary<string, string>()
        {
            {"A01", "664"},
            {"A03", "267"},
            {"A04", "3"},
            {"A05", "2"},
            {"A06", "6"},
            {"A07", "265"},
            {"A08", "242"},
            {"A09", "243"},
            {"A10", "1374"},
            {"A11", "1385"},
            {"A12", "1354"},
            {"A13", "1225"},
            {"A14", "983"},
            {"A15", "825"},
            {"A16", "816"},
            {"A17", "1771"},
            {"A18", "1799"},
            {"A19", "1806"},
            {"A20", "1817"},
            {"A21", "4419"},
            {"A22", "4424"},
            {"A23", "4429"},
            {"A24", "4443"},
            {"A25", "4493"},
            {"A26", "4522"},
            {"A27", "4581"},
            {"A28", "4723"},
            {"A29", "4946"},
            {"A30", "5085"},
            {"A31", "5376"},
            {"A32", "5082"},
            {"A33", "5083"},
            {"B01", "1132"},
            {"B02", "4"},
            {"B03", "5"},
            {"B04", "5778"},
            {"C01", "991"},
            {"C02", "3689"},
            {"C03", "266"},
            {"C04", "4433"},
            {"C05", "269"},
            {"C06", "270"},
            {"C07", "3688"},
            {"C08", "1816"},
            {"C09", "2358"},
            {"C10", "1816"},
            {"C11", "1820"},
            {"C12", "2519"},
            {"C13", "2383"},
            {"C14", "1818"},
            {"C15", "2676"},
            {"C16", "2923"},
            {"C17", "3080"},
            {"C18", "3453"},
            {"C19", "3298"},
            {"C20", "3455"},
            {"C21", "3454"},
            {"C22", "3898"},
            {"C23", "1"},
            {"C24", "5084"},
            {"S01", "2391"},
        };


        /// <summary>
        /// Need to fill
        /// </summary>
        private string rtFa = string.Empty;

        /// <summary>
        /// Need to fill
        /// </summary>
        private string fedAuth = string.Empty;

        private string cookieContent = string.Empty;

        /// <summary>
        /// Need to fill
        /// </summary>
        private string requestDigest = string.Empty;

        public OneDriveConnector(string cookieString, string requestdigest)
        {
            this.requestDigest = requestdigest;
            this.cookieContent = cookieString;
            ExtractCookie(cookieString);
        }

        public async void CreateLink(string materialId, string emailAddress)
        {
            string bodyTemplate = string.Empty;
            using (StreamReader reader = new StreamReader(bodyStringFile))
            {
                bodyTemplate = reader.ReadToEnd();
            }

            string body = bodyTemplate.Replace(@"{0}", emailAddress);

            if (!materialIdMapping.ContainsKey(materialId))
            {
                return;
            }

            string documentId = materialIdMapping[materialId];

            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var content = new StringContent(body, Encoding.UTF8, "application/json");

                cookieContainer.Add(baseAddress, new Cookie("ExcelWacDataCenter", "PUS2"));
                cookieContainer.Add(baseAddress, new Cookie("ExcelWacDaWacDataCentertaCenter", "PUS2"));
                cookieContainer.Add(baseAddress, new Cookie("cucg", "1"));
                cookieContainer.Add(baseAddress, new Cookie("rtFa", this.rtFa));
                cookieContainer.Add(baseAddress, new Cookie("FedAuth", this.fedAuth));
                
                //// client.DefaultRequestHeaders.Add("Cookie", cookieContent);

                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");

                client.DefaultRequestHeaders.Add("accept", "application/json");
                client.DefaultRequestHeaders.Add("x-requestdigest", this.requestDigest);

                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate,br");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US;q=0.8,en;q=0.7,zh-TW;q=0.6");

                client.DefaultRequestHeaders.Add("Referer", @"https://toneysui-my.sharepoint.com/personal/toneyisnow_toneysui_onmicrosoft_com/_layouts/15/sharedialog.aspx?listId={A4440530-D35E-4F78-B0C7-713F97907321}&listItemId=664&clientId=odb&ma=1");

                string fullUrl = string.Format(@"_api/web/Lists(@a1)/GetItemById(@a2)/ShareLink?@a1={0}&@a2=%27{1}%27", listIdEncoded, documentId);
                var response = await client.PostAsync(fullUrl, content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

            }
        }

        private void ExtractCookie(string cookieString)
        {
            string[] cookieItems = cookieString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string cookieItem in cookieItems)
            {
                int equal = cookieItem.IndexOf('=');
                if (equal < 0)
                {
                    continue;
                }

                string key = cookieItem.Substring(0, equal).Trim();
                string value = cookieItem.Substring(equal + 1).Trim();

                if (key == "rtFa")
                {
                    this.rtFa = value;
                }

                if (key == "FedAuth")
                {
                    this.fedAuth = value;
                }
            }
        }



    }
}
