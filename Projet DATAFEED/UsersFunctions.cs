using System.Data;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace PROJET_DATAFEED;
public class UsersFunctions
    {
        public void DisplayNameCities(Tuple<int, string, double, double>[] map)
        {
            Console.WriteLine("Choisir entre les villes suivantes : écrivez son numéro ! ");
            var i = 0;
            foreach (var ville in map)
            {
                i++;
                Console.WriteLine($"\t{i} ) {ville.Item2}");
            }
        }
        
        public int UserChoice()
        {
            int x;
            Console.Write("Rentrez le numéro de ville: ");
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("You entered an invalid number");
                Console.Write("Rentrez le numéro de ville:  ");
            }
            return x;
        }
        
        public async void UserWeather(Tuple<int, string, double, double>[] map, int x)
        {
            var api = new WeatherApp();
            foreach (var ville in map)
            {
                if (ville.Item1 == x)
                {
                    Root obj = new Root();
                    RootAirQuality objAq = new RootAirQuality();
                    var city = new Coordinates(ville.Item3, ville.Item4);
                    obj = api.GetWeather(city);
                    objAq = api.GetAirQuality(city);
                    Console.WriteLine("Concernant la qualité de l'air : 1/5 = Bon, 2/5 = Passable, 3/5 = Modéré, 4/5 = Mauvais, 5/5 = Très mauvais.\n");
                    foreach (ListAirQuality list in objAq.list)
                    {
                        
                        Console.WriteLine(
                            $"\tTemperature à {ville.Item2} : {(obj.current.temp) - (272.15)}°\n\tLe ressenti est de {(obj.current.feels_like) - (272.15)}°\n\tL'humidité est de {obj.current.humidity}%\n\tle vent est à {obj.current.wind_speed}m/s \n\tQualité de l'air à {ville.Item2} : {list.main.aqi}/5");
                        Console.WriteLine("");
                    }
                }
            }
        }

    public async void UserWeatherChoosen(Coordinates x)
    {
        var api = new WeatherApp();
                Root obj = new Root();
                RootAirQuality objAq = new RootAirQuality();
                obj = api.GetWeather(x);
                objAq = api.GetAirQuality(x);
                Console.WriteLine("Concernant la qualité de l'air : 1/5 = Bon, 2/5 = Passable, 3/5 = Modéré, 4/5 = Mauvais, 5/5 = Très mauvais.");
                foreach (ListAirQuality list in objAq.list)
                {

                    Console.WriteLine(
                        $"Temperature à {x.lat}, {x.lon}: {(obj.current.temp) - (272.15)}°\n\tLe ressenti est de {(obj.current.feels_like) - (272.15)}°\n\tL'humidité est de {obj.current.humidity}%\n\tle vent est à {obj.current.wind_speed}m/s \n\tQualité de l'air à {x.lat}, {x.lon} : {list.main.aqi}/5");
                    Console.WriteLine("");
                }
    }

    public void UserWeatherFuture(Tuple<int, string, double, double>[] map, int x)
        {
            var api = new WeatherApp();
            foreach (var ville in map)
            {
                if (ville.Item1 == x)
                {
                    RootFuture obj = new RootFuture();
                    var city = new Coordinates(ville.Item3, ville.Item4);
                    obj = api.GetWeatherFuture(city);
                    Console.WriteLine("Prévision pour les 5 prochains jours toute les 3H : \n");
                    Console.WriteLine("");
                    foreach (List list in obj.list)
                    {
                        Console.WriteLine($"Prévision météorologique à {ville.Item2} à la date:{list.dt_txt}\n\tLa température est à {list.main.temp - (272.15)}°\n\tLe ressenti est de {(list.main.feels_like) - (272.15)}\n\tL'humidité est à {list.main.humidity}%\n\tIl y a {list.pop * 100}% de chance qu'il pleuve\n");
                    }
                }
            }
        }

    public void UserWeatherFutureChoosen(Coordinates x)
    {
        var api = new WeatherApp();
        RootFuture obj = new RootFuture();
        obj = api.GetWeatherFuture(x);
        Console.WriteLine("Prévision pour les 5 prochains jours toute les 3H : ");
        Console.WriteLine("");
        foreach (List list in obj.list)
        {
             Console.WriteLine($"Temperature à {x.lat}, {x.lon} à la date:{list.dt_txt}:\n\tLa température est à {list.main.temp - (272.15)}°\n\tLe ressenti est de {(list.main.feels_like) - (272.15)}\n\tL'humidité est à {list.main.humidity}%\n\tIl y a {list.pop * 100}% de chance qu'il pleuve\n");
        }
    }

    public void TomorrowWeather(Tuple<int, string, double, double>[] map, int x)
        {
            var api = new WeatherApp();
            foreach (var ville in map)
            {
                if (ville.Item1 == x)
                {
                    Console.WriteLine("Affichage de la météo de demain toute les 3H : ");
                    Console.WriteLine("");
                    RootFuture obj = new RootFuture();
                    var city = new Coordinates(ville.Item3, ville.Item4);
                    obj = api.GetWeatherFuture(city);
                    foreach (List list in obj.list)
                    {
                        var tomorrow = DateTime.Today.AddDays(1);
                        string tomorrowString = tomorrow.ToString("yyy-MM-dd");
                        if ((list.dt_txt).Contains(tomorrowString))
                        {
                            Console.WriteLine($"Météo le {list.dt_txt} (demain): \n\tLa température sera de {list.main.temp - (272.15)}°\n\tLe ressenti sera de {list.main.feels_like - (272.15)}°\n\tL'humidité sera de {list.main.humidity}%\n\tIl y a {list.pop * 100}% de chance qu'il pleuve\n");
                        }
                    }
                }
            }

        }

    public void TomorrowWeatherChoosen(Coordinates x)
    {
        var api = new WeatherApp();
        Console.WriteLine("Affichage de la météo de demain toute les 3H : ");
        Console.WriteLine("");
        RootFuture obj = new RootFuture();
        obj = api.GetWeatherFuture(x);
        foreach (List list in obj.list)
        {
            var tomorrow = DateTime.Today.AddDays(1);
            string tomorrowString = tomorrow.ToString("yyy-MM-dd");
            if ((list.dt_txt).Contains(tomorrowString))
              {
                  Console.WriteLine($"Météo le {list.dt_txt} à {x.lat}, {x.lon}:\n\tLa température sera de {list.main.temp - (272.15)}°\n\tLe ressenti sera de {list.main.feels_like - (272.15)}°\n\tL'humidité sera de {list.main.humidity}%\n\tIl y a {list.pop * 100}% de chance qu'il pleuve\n");
              }
        }
    }

    public Coordinates AskCoordinates()
        {
            Console.WriteLine("Rentre la latitude : ");
            double latitude = double.Parse(Console.ReadLine());
            Console.WriteLine("Rentre la longitude : ");
            double longitude = double.Parse(Console.ReadLine());
            var coord = new Coordinates(latitude, longitude);
            return coord;
        }

}
