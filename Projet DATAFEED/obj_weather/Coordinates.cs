namespace PROJET_DATAFEED;

public class Coordinates
{
    public double lon { get; set; }
    public double lat { get; set; }

    public Coordinates(double latitude, double longitude)
    {
        lon = longitude;
        lat = latitude;
    }
}