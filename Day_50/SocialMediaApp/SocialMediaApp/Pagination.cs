namespace SocialMediaApp
{
    public class Pagination
    {
        public int Results { get; set; }
        public int Page { get; set; }

        //firstname..
        public string OrderBy { get; set; }
        //asc | desc
        public string SortOrder { get; set; }

    }
}
