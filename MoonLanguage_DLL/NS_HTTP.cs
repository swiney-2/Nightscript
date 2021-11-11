using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;

namespace Nightscript
{
    class NS_HTTP
    {
        /// <summary>
        /// Returns the raw text of a Uri (string Url)
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static string LOAD_STRING_URL(Uri Url)
        {
            using (WebClient wbc = new WebClient())
            {
                return wbc.DownloadString(Url);
            }
        }
        /// <summary>
        /// Sends an HTTP request ("Method") to Uri "URL"
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Method"></param>
        public static void WEB_REQUEST(Uri Url, string Method)
        {
            using (HttpClient HttpClient = new HttpClient())
            {
                try
                {
                    switch (Method)
                    {
                        case "GET":
                            HttpClient.GetAsync(Url);
                            break;
                        case "DELETE":
                            HttpClient.DeleteAsync(Url);
                            break;
                        default:
                            throw new Exception("Invalid HttpRequest method.\nPlease use GET or DELETE");
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show($"Caught Exception: \n{Ex.Message}\n\nPlease Retry", "Moon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
