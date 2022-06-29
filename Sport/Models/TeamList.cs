namespace Sport.Models
{
    public class TeamList
    {
        public List<Data4> data { get; set; }
    }

    public class Data4
    {
        public int? id { get; set; }
        public int? sport_id { get; set; }
        public int? manager_id { get; set; }
        public string logo { get; set; }
        public string name { get; set; }
        public string country { get; set; }
    }
}
