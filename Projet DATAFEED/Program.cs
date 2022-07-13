using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROJET_DATAFEED;
public class Program
{
    public static async Task Main(string[] args)
    {


        Tuple<int, string, double, double>[] Villes =
        {   Tuple.Create(1, "Paris", 48.856614, 2.3522219),
            Tuple.Create(2, "Berlin", 52.520007, 13.404954),
            Tuple.Create(3, "Tokyo", 35.6894, 139.692),
            Tuple.Create(4, "Kiev", 50.4501, 30.5234),
            Tuple.Create(5, "Moscow", 55.755826, 37.6173),
            Tuple.Create(6, "Barcelone", 41.3887900, 2.1589900),
            Tuple.Create(7, "New-York", 40.712784, -74.005941),
            Tuple.Create(8, "Pekin", 39.9075000, 116.3972300),
            Tuple.Create(9, "Marseille", 43.2969500, 5.3810700),
            Tuple.Create(10, "Londres", 51.5085300, -0.1257400) };

        var usersFunctions = new UsersFunctions();
        var api = new WeatherApp();

        string menuchoice = "";
        int choose = 0;
        Coordinates coor = new Coordinates(0, 0);
        while (menuchoice != "E")
        {
            int city = 0;
            Console.WriteLine("-----Choose an option-----");
            Console.WriteLine("\t1) Rentrer des coordonnées");
            Console.WriteLine("\t2) choisir une ville préenregistrée");
            Console.WriteLine("\tE) Quitter");
            Console.Write("\r\nSelect an option: ");

            menuchoice = Console.ReadLine();
            switch (menuchoice)
            {
                case "1":
                    coor = usersFunctions.AskCoordinates();
                    choose = 1;
                    break;
                case "2":
                    usersFunctions.DisplayNameCities(Villes);
                    city = usersFunctions.UserChoice();
                    Console.WriteLine("");
                    break;
                case "E":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Sorry, invalid selection");
                    break;
            }

            Console.WriteLine("-----Choose an option-----");

            Console.WriteLine("\t1) météo actuelle ");
            Console.WriteLine("\t2) météo des 5 prochains jours");
            Console.WriteLine("\t3) météo de demain ");
            Console.WriteLine("\tE) Quitter");
            Console.Write("\r\nSelect an option: ");

            menuchoice = Console.ReadLine();
            if (choose == 0)
            {
                switch (menuchoice)
                {
                    case "1":
                        usersFunctions.UserWeather(Villes, city); ;
                        break;
                    case "2":
                        usersFunctions.UserWeatherFuture(Villes, city); ;
                        break;
                    case "3":
                        usersFunctions.TomorrowWeather(Villes, city); ;
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid selection");
                        break;
                }
            }
            else
            {
                switch (menuchoice)
                {
                    case "1":
                        usersFunctions.UserWeatherChoosen(coor); ;
                        break;
                    case "2":
                        usersFunctions.UserWeatherFutureChoosen(coor); ;
                        break;
                    case "3":
                        usersFunctions.TomorrowWeatherChoosen(coor); ;
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid selection");
                        break;
                }

            }
        }
    }
}