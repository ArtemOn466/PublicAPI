namespace Sport.Models
{
    public class RefereeList
    {
        public List<Data2> data { get; set; }
    }

    public class Data2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nationality_code { get; set; }
        public string? photo { get; set; }
        public int yellow_cards { get; set; }
        public int red_cards { get; set; }
        public int games { get; set; }

    }

}
