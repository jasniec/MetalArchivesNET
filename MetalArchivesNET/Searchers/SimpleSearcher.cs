using MetalArchivesNET.Parsers;
using MetalArchivesNET.Searchers.Configurators.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetalArchivesNET.Searchers
{
    /// <summary>
    /// Performs simple search of Items: Band, Album, Song, Lyrical themes, Music genre
    /// </summary>
    /// <typeparam name="T">Search result class. Result will be deserialised as this class</typeparam>
    public class SimpleSearcher<T> where T : class, new()
    {
        internal SimpleSearcher(IConfigurator configurator)
        {
            _configurator = configurator;
        }

        private readonly IConfigurator _configurator;

        /// <summary>
        /// Searches item by name.
        /// </summary>
        /// <param name="name">Item's name</param>
        /// <returns>List of items result - without pagination, all rows at once</returns>
        public IEnumerable<T> ByName(string name)
        {
            List<T> items = new List<T>();
            _configurator.Parameters["query"] = name;
            var wd = new WebDownloader(_configurator.Url, _configurator.Parameters);
            IEnumerable<T> itemsToAdd;
            int page = 0;

            do
            {
                _configurator.Parameters["iDisplayStart"] = (page++ * 200).ToString();
                var response = wd.DownloadData();

                itemsToAdd = ProcessParse(response);
                items.AddRange(itemsToAdd);
            }
            while (itemsToAdd.Count() != 0);

            return items;
        }

        /// <summary>
        /// Searches item by name async.
        /// </summary>
        /// <param name="name">Item's name</param>
        /// <returns>List of items result - without pagination, all rows at once</returns>
        public async Task<IEnumerable<T>> ByNameAsync(string name)
        {
            List<T> items = new List<T>();
            _configurator.Parameters["query"] = name;
            var wd = new WebDownloader(_configurator.Url, _configurator.Parameters);
            IEnumerable<T> itemsToAdd;
            int page = 0;

            do
            {
                _configurator.Parameters["iDisplayStart"] = page++.ToString();
                var response = await wd.DownloadDataAsync();

                itemsToAdd = ProcessParse(response);
                items.AddRange(itemsToAdd);
            }
            while (itemsToAdd.Count() != 0);

            return items;
        }

        private IEnumerable<T> ProcessParse(string content)
        {
            var parser = new ResponseParser<T>();

            return parser.Parse(content);
        }

    }
}
