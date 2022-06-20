namespace Advanced_C_Sharp.Models
{
    public class SearchResult : ISearchResult
    {
        public string ResourceName { get; set; }

        public ResourceType Type { get; set; }

        public SearchResult(string resourceName, ResourceType type)
        {
            ResourceName = resourceName;
            Type = type;
        }
    }
}
