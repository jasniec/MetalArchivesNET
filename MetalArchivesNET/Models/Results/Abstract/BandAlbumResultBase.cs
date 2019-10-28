using MetalArchivesNET.Models.Results.FullResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsiteParser;

namespace MetalArchivesNET.Models.Results.Abstract
{
    public abstract class BandAlbumResultBase : BandResultBase
    {
        /// <summary>
        /// Url address to album
        /// </summary>
        public abstract string AlbumUrl { get; set; }

        /// <summary>
        /// Get album's page
        /// </summary>
        /// <returns>Parsed album's page</returns>
        public AlbumResult GetFullAlbum()
        {
            WebDownloader downloader = new WebDownloader(AlbumUrl);
            string content = downloader.DownloadData();

            return WebContentParser.Parse<AlbumResult>(content);
        }

        /// <summary>
        /// Get album's page async
        /// </summary>
        /// <returns>Parsed album's page</returns>
        public async Task<AlbumResult> GetFullAlbumAsync()
        {
            WebDownloader downloader = new WebDownloader(AlbumUrl);
            string content = await downloader.DownloadDataAsync();

            return WebContentParser.Parse<AlbumResult>(content);
        }
    }
}
