namespace Sport.Models
{
    public class SaveReferee
    {
        public data2 data { get; set; }
    }
    public class data2
    {
        public string name { get; set; }
        public string nationality_code { get; set; }
        public string? photo { get; set; }
        public int yellow_cards { get; set; }
        public int red_cards { get; set; }
        public int games { get; set; }
    }
}
