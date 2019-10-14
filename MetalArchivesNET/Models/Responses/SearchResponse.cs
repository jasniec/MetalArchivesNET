namespace MetalArchivesNET.Models.Responses
{
    /// <summary>
    /// Ajax response from server
    /// </summary>
    class SearchResponse
    {
        public string error { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public int sEcho { get; set; }
        public string[][] aaData { get; set; }
    }
}
