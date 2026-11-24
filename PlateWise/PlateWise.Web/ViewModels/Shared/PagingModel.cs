namespace PlateWise.Web.ViewModels.Shared
{
    public class PagingModel
    {
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }

        public string Action { get; set; } = "Index";

        public string? Controller { get; set; }

        public Dictionary<string, string> RouteValues { get; set; } = new();

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;

        public Dictionary<string, string> RouteForPage(int page)
        {
            var values = new Dictionary<string, string>(RouteValues)
            {
                ["page"] = page.ToString()
            };

            return values;
        }
    }
}
