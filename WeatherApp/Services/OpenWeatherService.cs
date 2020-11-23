using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    public class OpenWeatherService : ITemperatureService
    {
        OpenWeatherProcessor owp;

        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }
        
        public async Task<TemperatureModel> GetTempAsync()
        {
            var temp = await owp.GetCurrentWeatherAsync();

            if(temp.Cod == 404)
            {
                MessageBox.Show("Please be sure you've set a valid City name. \n Code Error = 404");
                return new TemperatureModel();
            }
            else if(temp.Cod == 401)
            {
                MessageBox.Show("Please be sure you've set a valid ApiKey. \n Code Error = 401");
                return new TemperatureModel();
            }
            else if (temp == null || temp.Cod == 400)
            {
                MessageBox.Show("There was an error while loading temperature. Nothing to geocode. \n Code Error = 400");
                return new TemperatureModel();
            }
            else
            {
                var result = new TemperatureModel
                {
                    DateTime = DateTime.UnixEpoch.AddSeconds(temp.DateTime),
                    Temperature = temp.Main.Temperature
                };
                return result;
            }
        }

        public void SetLocation(string location)
        {
            owp.City = location;
        }

        public void SetApiKey(string apikey)
        {
            owp.ApiKey = apikey;
        }
    }
}
