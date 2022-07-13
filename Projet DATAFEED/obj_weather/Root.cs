namespace PROJET_DATAFEED
{

    public class Root
    {
        public Coordinates coord { get; set; }
        public List<CurrentWeatherObj> weather { get; set; }
        public string @base { get; set; }
        public int visibility { get; set; }
        public int dt { get; set; }
        public string timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public Current current { get; set; }
        public List<Daily> daily { get; set; }
        public Temp temp { get; set; }
    }
}