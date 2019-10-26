using MetalArchivesNET.Models.Results.FullResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsiteParser;

namespace MetalArchivesNET.Models.Results.Abstract
{
    /// <summary>
    /// Result's base that contains reference to a band
    /// </summary>
    public abstract class BandResultBase
    {

        /// <summary>
        /// Band's url address
        /// </summary>
        public abstract string BandUrl { get; set; }

        /// <summary>
        /// Get band's page
        /// </summary>
        /// <returns>Parsed band's page</returns>
        public BandResult GetBand()
        {
            WebDownloader downloader = new WebDownloader(BandUrl);
            string content = downloader.DownloadData();

            return WebContentParser.Parse<BandResult>(content);
        }

        /// <summary>
        /// Get band's page async
        /// </summary>
        /// <returns>Parsed band's page</returns>
        public async Task<BandResult> GetBandAsync()
        {
            WebDownloader downloader = new WebDownloader(BandUrl);
            string content = await downloader.DownloadDataAsync();

            return WebContentParser.Parse<BandResult>(content);
        }
    }
}
