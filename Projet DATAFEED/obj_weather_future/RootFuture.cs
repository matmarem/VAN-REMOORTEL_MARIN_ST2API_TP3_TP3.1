namespace PROJET_DATAFEED
{

    public class RootFuture
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public Main main { get; set; }
        public City city { get; set; }
    }
}