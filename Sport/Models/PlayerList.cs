namespace Sport.Models
{
    public class PlayerList
    {
        public List<Data> data { get; set; }
    }

    public class Data
    {
        public int? id { get; set; } 
        public int? sport_id { get; set; }
        public string? name { get; set; }
        public string? position_name { get; set; }
        public int? weight { get; set; }
        public int age { get; set; }
        public DateTime date_birth_at { get; set; }
        public double? height { get; set; }
        public int shirt_number { get; set; }
        public string preferred_foot { get; set; }
        public string? nationality_code { get; set; }
        public int? market_value { get; set; }
        public main_team? main_team { get; set; }

    }

    public class main_team
    {
        public string? name { get; set; }
    }

}
