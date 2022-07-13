using PROJET_DATAFEED;
namespace WeatherTests
{
    [TestClass]
    public class WeatherTests
    {
        [TestMethod]
        public static void ValideTempType()
        {
            var expected = typeof(double);

            var api = new WeatherApp();
            var city = new Coordinates(48.856614, 2.3522219);
            Root obj = new Root();
            obj = api.GetWeather(city);
            var temp = obj.current.temp.GetType();

            Assert.AreEqual(temp, expected);
        }

        [TestMethod]
        public static void ValideHumidityType()
        {
            var expected = typeof(Int32);

            var api = new WeatherApp();
            var city = new Coordinates(48.856614, 2.3522219);
            Root obj = new Root();
            obj = api.GetWeather(city);
            var humidity = obj.current.humidity.GetType();

            Assert.AreEqual(humidity, expected);
        }

        [TestMethod]
        public static void ValidePressureType()
        {
            var expected = typeof(Int32);

            var api = new WeatherApp();
            var city = new Coordinates(48.856614, 2.3522219);
            Root obj = new Root();
            obj = api.GetWeather(city);
            var pressure = obj.current.pressure.GetType();

            Assert.AreEqual(pressure, expected);
        }

        [TestMethod]
        public static void CheckObjNotNull()
        {
            var api = new WeatherApp();
            var city = new Coordinates(48.856614, 2.3522219);
            Root obj = new Root();
            obj = api.GetWeather(city);

            Assert.IsNotNull(obj);
        }
    }
}