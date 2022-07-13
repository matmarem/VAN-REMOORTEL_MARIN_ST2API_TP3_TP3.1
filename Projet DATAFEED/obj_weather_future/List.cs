namespace PROJET_DATAFEED
{

    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<WeatherFuture> weather { get; set; }
        public WindFuture wind { get; set; }
        public int visibility { get; set; }
        public double pop { get; set; }
        public string dt_txt { get; set; }
        public RainFuture rain { get; set; }
    }
}