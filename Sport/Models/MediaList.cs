namespace Sport.Models
{
    public class MediaList
    {
        public List<Data8> data { get; set; }
    }

    public class Data8
    {
        public int? id { get; set; }
        public string? source_type { get; set; }
        public int? source_id { get; set; }
        public title? title { get; set; }
        public string? url { get; set; }
    }

    public class title
    {
        public string? en { get; set; }
    }
}
