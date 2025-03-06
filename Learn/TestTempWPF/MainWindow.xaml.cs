using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new();

        private double _lat;
        private double _lon;
        private string _city = string.Empty;
        
        private const string ApiKey = "874b3113e356fe291e1096218bdf76a9";

        private DispatcherTimer? _updateTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Позволяет перетаскивать окно за любой участок Grid
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private async void GetTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            _city = CityTextBox.Text.Trim();
            if (string.IsNullOrEmpty(_city))
            {
                StatusTextBlock.Text = "Введите название города.";
                return;
            }

            // Останавливаем предыдущий таймер, если он уже был
            _updateTimer?.Stop();
            TemperatureTextBlock.Text = string.Empty;
            
            StatusTextBlock.Text = "Загрузка...";

            try
            {
                await Task.Delay(1000);
                
                string geoUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={Uri.EscapeDataString(_city)}&limit=1&appid={ApiKey}";
                HttpResponseMessage geoResponse = await _httpClient.GetAsync(geoUrl);
                if (!geoResponse.IsSuccessStatusCode)
                {
                    StatusTextBlock.Text = "Ошибка получения координат.";
                    return;
                }

                string geoContent = await geoResponse.Content.ReadAsStringAsync();
                List<GeoResponse>? geoArray = JsonSerializer.Deserialize<List<GeoResponse>>(geoContent);
                if (geoArray == null || geoArray.Count == 0)
                {
                    StatusTextBlock.Text = "Город не найден.";
                    return;
                }

                _lat = geoArray[0].lat;
                _lon = geoArray[0].lon;
                
                await UpdateTemperature();

                CreateTimer();
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Ошибка: " + ex.Message;
            }
        }

        private async void CreateTimer()
        {
            await WaitBeforeClosestMinute();
            await UpdateTemperature();
            _updateTimer = new DispatcherTimer();
            _updateTimer.Tick += UpdateTimer_Tick;
            _updateTimer.Interval = TimeSpan.FromMinutes(1);
            _updateTimer.Start();
        }

        private static async Task WaitBeforeClosestMinute()
        {
            DateTime now = DateTime.Now;
            DateTime nextMinute = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0).AddMinutes(1);
            TimeSpan difference = nextMinute - now;
            
            await Task.Delay(difference);
        }

        private async void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            await UpdateTemperature();
        }

        private async Task UpdateTemperature()
        {
            try
            {
                string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={_lat}&lon={_lon}&appid={ApiKey}&units=metric";
                HttpResponseMessage weatherResponse = await _httpClient.GetAsync(weatherUrl);
                if (!weatherResponse.IsSuccessStatusCode)
                {
                    StatusTextBlock.Text = "Ошибка получения температуры.";
                    return;
                }

                string weatherContent = await weatherResponse.Content.ReadAsStringAsync();
                WeatherResponse? weatherData = JsonSerializer.Deserialize<WeatherResponse>(weatherContent);
                if (weatherData?.main == null)
                {
                    StatusTextBlock.Text = "Ошибка обработки данных.";
                    return;
                }

                double temp = weatherData.main.temp;
                TemperatureTextBlock.Text = $"{temp:F1} °C";
                StatusTextBlock.Text = "Обновлено: " + DateTime.Now.ToLongTimeString();
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Ошибка: " + ex.Message;
            }
        }
    }
    
    public class GeoResponse
    {
        public string name { get; set; } = string.Empty;
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class MainInfo
    {
        public double temp { get; set; }
    }

    public class WeatherResponse
    {
        public MainInfo? main { get; set; }
    }
}
