using System.Collections.Generic;


namespace HSHackerNewsConsol
{
    public class HackerNewsData
    {
        public string Title { get; set; }
        public List<HackerNewsFeed> Items { get; set; }
    }

    public class HackerNewsFeed
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        //public string external_url { get; set; }// json has this field so can use
        public string Date_Published { get; set; }
        // public string content_html { get; set; }//  json has this field so can use
        public string Author { get; set; }
        // public string points { get; set; }
    }

}
