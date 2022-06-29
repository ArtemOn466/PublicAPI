namespace Sport.Models
{
    public class EventListByDate
    {
        public List<Data7>? data { get; set; }
    }

    public class Data7
    {
        public string name { get; set; }
        public DateTime start_at { get; set; }
        public home_score2 home_score { get; set; }
        public away_score2 away_score { get; set; }
        public league2 league { get; set; }
        public season season { get; set; }
        public sport1 sport { get; set; }
    }

    public class home_score2
    {
        public int? current { get; set; }
    }

    public class away_score2
    {
        public int? current { get; set; }
    }

    public class league2
    {
        public string? name { get; set; }
    }

    public class season
    {
        public string? name { get; set; }
        public int year_start { get; set; }
    }

    public class sport1
    {
        public string name { get; set; }
    }
}
