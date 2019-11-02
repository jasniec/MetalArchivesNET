using System;
using System.Collections.Generic;
using System.Text;
using WebsiteParser.Attributes;
using WebsiteParser.Attributes.Enums;
using WebsiteParser.Attributes.StartAttributes;
using WebsiteParser.Converters;

namespace MetalArchivesNET.Models.Results.PartResults
{
    /// <summary>
    /// Footer's information about add and update
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Name of user who added band
        /// </summary>
        [Selector(@"table tr:first-child td:first-child", EmptyValues = new string[] { "Added by: (Unknown user)" })]
        [Remove("Added by: ", RemoverValueType.Text)]
        public string AddedBy { get; set; }

        /// <summary>
        /// Band's page add date
        /// </summary>
        [Selector(@"table tr:nth-child(2) td:first-child", EmptyValues = new string[] { "Added on: N/A" })]
        [Regex(@"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})")]
        [Converter(typeof(DateTimeConverter))]
        public DateTime AddDate { get; set; }

        /// <summary>
        /// Last modification user's name
        /// </summary>
        [Selector(@"table tr:first-child td:last-child", EmptyValues = new string[] { "Added by: (Unknown user)" })]
        [Remove("Modified by: ", RemoverValueType.Text)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Last modification date
        /// </summary>
        [Selector(@"table tr:nth-child(2) td:nth-child(2)", EmptyValues = new string[] { "Added on: N/A" })]
        [Regex(@"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})")]
        [Converter(typeof(DateTimeConverter))]
        public DateTime ModifiedDate { get; set; }
    }
}
