using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MetalArchivesNET
{
    class WebDownloader
    {
        /// <summary>
        /// Creates instance of WebDownloader.
        /// </summary>
        /// <param name="url">As string format</param>
        /// <param name="parameters">name-value GET parameters</param>
        public WebDownloader(string url, Dictionary<string, string> parameters)
        {
            _url = url;
            _parameters = parameters ?? new Dictionary<string, string>();
        }

        readonly string _url;
        readonly Dictionary<string, string> _parameters;

        public string DownloadData()
        {
            return DownloadDataAsync().Result;
        }

        public async Task<string> DownloadDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync(PrepareUrl(_url, _parameters));

                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"An error ocurred during performing the request. Response code: {response.StatusCode}");
            }
        }

        private string PrepareUrl(string url, Dictionary<string, string> parameters)
        {
            string p = parameters?.Count > 0
                ? "?" + string.Join("&", parameters.Select(i => $"{i.Key}={HttpUtility.UrlEncode(i.Value)}"))
                : string.Empty;

            return url + p;
        }
    }
}