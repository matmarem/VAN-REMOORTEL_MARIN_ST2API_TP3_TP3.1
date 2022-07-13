using System.Data;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PROJET_DATAFEED
{
    public class WeatherApp
    {
        private HttpClient httpClient { get; set; }
        private const string ApiKey = "bbe8fe51aa7d630332569e6f1e92fb77";

        public WeatherApp()
        {
            httpClient = new HttpClient();
        }

        public Root GetWeather(Coordinates coord)
        {
            var uri = Build(coord.lat, coord.lon);
            string json = Connect(uri).GetAwaiter().GetResult();
            Root data = JsonConvert.DeserializeObject<Root>(json);
            return data;
        }

        public RootFuture GetWeatherFuture(Coordinates coord)
        {
            var uri = BuildFuture(coord.lat, coord.lon);
            string json = Connect(uri).GetAwaiter().GetResult();
            RootFuture data = JsonConvert.DeserializeObject<RootFuture>(json);
            return data;
        }
        
        public RootAirQuality GetAirQuality(Coordinates coord)
        {
            var uri = BuildAirQuality(coord.lat, coord.lon);
            string json = Connect(uri).GetAwaiter().GetResult();
            RootAirQuality data = JsonConvert.DeserializeObject<RootAirQuality>(json);
            return data;
        }

        public static Uri Build(double latitude, double longitude)
        {
            string path =
                $"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&appid={ApiKey}";
            Uri uri = new Uri(path);
            return uri;
        }

        private static Uri BuildFuture(double latitude, double longitude)
        {
            string path =
                $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&appid={ApiKey}";
            Uri uri = new Uri(path);
            return uri;
        }
        
        private static Uri BuildAirQuality(double latitude, double longitude)
        {
            string path =
                $"http://api.openweathermap.org/data/2.5/air_pollution?lat={latitude}&lon={longitude}&appid={ApiKey}";
            Uri uri = new Uri(path);
            return uri;
        }


        private async Task<string> Connect(Uri uri)
        {
            var data = string.Empty;
            try
            {
                HttpClient client = new HttpClient();
                var responseBody = await client.GetAsync(uri);
                data = await responseBody.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException!");
                Console.WriteLine("Message: {0} ", e.Message);
            }
            return data;
        }
    }
}