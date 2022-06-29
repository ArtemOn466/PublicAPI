namespace Sport.Models
{
    public class EventLiveList
    {
        public List<Data6> data { get; set; }
    }

    public class Data6
    {
        public int? id { get; set; }
        public int? sport_id { get; set; }
        public int? league_id { get; set; }
        public int? referee_id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string status_more { get; set; }
        public home_team1 home_team { get; set; }
        public away_team1 away_team { get; set; }
        public home_score1 home_score { get; set; }
        public away_score1 away_score { get; set; }
        public DateTime start_at { get; set; }
        public league1 league { get; set; }
        public sport sport { get; set; }

    }

    public class home_team1
    {
        public string name { get; set; }
        public char? gender { get; set; }

    }

    public class away_team1
    {
        public string name { get; set; }
        public char? gender { get; set; }
    }

    public class league1
    {
        public string name { get; set; }
    }

    public class sport
    {
        public string name { set; get; }
    }
    
    public class home_score1
    {
        public int current { get; set; }
    }

    public class away_score1
    {
        public int current { set; get; }
    }
}
