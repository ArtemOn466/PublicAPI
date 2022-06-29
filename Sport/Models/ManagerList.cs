namespace Sport.Models
{
    public class ManagerList
    {
        public List<Data5> data { get; set; }
    }

    public class Data5
    {
        public int? id { get; set; }
        public int sport_id { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public DateTime? date_birth { get; set; }
        public string? nationality_code { get; set; }    
        public string? preferred_formation { get; set; }
        public team1 team { get; set; }
        public per performance { get; set; }
    }
    public class team1
    {
        public string? name { get; set; }
    }

    public class per
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int draws { get; set; }
        public int goals_scored { get; set; }
        public int goals_conceded { get; set; }
        public int total_points { get; set; }
    }
}
