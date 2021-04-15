using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace WeatherApp
{
    public partial class Form1 : Form
    {
        const string APPID = "542ffd081e67f4512b705f89d2a611b2";
        string cityName = "Vilnius";
        public Form1()
        {
            InitializeComponent();
            getWeather("Kaunas");// one day weather
            getForcast("Kaunas");// more than one day
        }

          void getWeather(string city)
    
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", city, APPID);

                var json = web.DownloadString(url);
                var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                WeatherInfo.root outPut = result;

                label1.Text = string.Format("{0}", outPut.name);
                picturebox1.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);
                label2.Text = string.Format("{0}", outPut.sys.country);
                label3.Text = string.Format("{0} \u00B0" + "C", outPut.main.temp);
            }
        }

         void getForcast(string city)
        {
            int day = 6;
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt={1}&APPID={2}",city, day, APPID);
            using(WebClient web = new WebClient())
            {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<weatherForcast>(json);

                weatherForcast forcast = Object;

                // next day
                label4.Text = string.Format("{0}", getDate(forcast.list[1].dt).DayOfWeek);//returning Day
                label5.Text = string.Format("{0}", forcast.list[1].weather[0].main);//weather condition
                label6.Text = string.Format("{0}", forcast.list[1].weather[0].description);//weather description
                label8.Text = string.Format("{0}\u00B0"+"C", forcast.list[1].temp.day);//weather temp
                label7.Text = string.Format("{0} km/h", forcast.list[1].speed);//weather wind speed

                //day after tomorrow
                label14.Text = string.Format("{0}", getDate(forcast.list[2].dt).DayOfWeek);//returning Day
                label13.Text = string.Format("{0}", forcast.list[2].weather[0].main);//weather condition
                label12.Text = string.Format("{0}", forcast.list[2].weather[0].description);//weather description
                label10.Text = string.Format("{0}\u00B0" + "C", forcast.list[2].temp.day);//weather temp
                label11.Text = string.Format("{0} km/h", forcast.list[2].speed);//weather wind speed

                //next other day
                label19.Text = string.Format("{0}", getDate(forcast.list[3].dt).DayOfWeek);//returning Day
                label18.Text = string.Format("{0}", forcast.list[3].weather[0].main);//weather condition
                label17.Text = string.Format("{0}", forcast.list[3].weather[0].description);//weather description
                label15.Text = string.Format("{0}\u00B0" + "C", forcast.list[3].temp.day);//weather temp
                label16.Text = string.Format("{0} km/h", forcast.list[3].speed);//weather wind speed

                //next next other day
                label25.Text = string.Format("{0}", getDate(forcast.list[4].dt).DayOfWeek);//returning Day
                label24.Text = string.Format("{0}", forcast.list[4].weather[0].main);//weather condition
                label23.Text = string.Format("{0}", forcast.list[4].weather[0].description);//weather description
                label21.Text = string.Format("{0}\u00B0" + "C", forcast.list[4].temp.day);//weather temp
                label22.Text = string.Format("{0} km/h", forcast.list[4].speed);//weather wind speed

                //next next next other day
                label30.Text = string.Format("{0}", getDate(forcast.list[5].dt).DayOfWeek);//returning Day
                label29.Text = string.Format("{0}", forcast.list[5].weather[0].main);//weather condition
                label28.Text = string.Format("{0}", forcast.list[5].weather[0].description);//weather description
                label26.Text = string.Format("{0}\u00B0" + "C", forcast.list[5].temp.day);//weather temp
                label27.Text = string.Format("{0} km/h", forcast.list[5].speed);//weather wind speed


            }
        }

         DateTime getDate(double millisecound)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecound).ToLocalTime();

            return day;
        }
    }

   
}
