using AppMusic.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.UI.Xaml.Controls;

namespace AppMusic.Service
{
    public class SongService
    {
        private static string ApiBaseUrl = "https://music-i-like.herokuapp.com";
        private static string ApiSongPath = "/api/v1/songs";
        private static string ApiDataType = "application/json";
        public async Task<bool> Save(Song song)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(song);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await httpClient.PostAsync(ApiSongPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Thong bao";
                dialog.Content = $"{e.Message}";
                dialog.CloseButtonText = "Cancel";
                dialog.DefaultButton = ContentDialogButton.Primary;
                await dialog.ShowAsync();
                return false;

            }
        }
        public async Task<List<Song>> FindAll()
        {
            List<Song> list = new List<Song>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var result = await httpClient.GetAsync(ApiSongPath); // gửi request lên server.
                    var resultContent = await result.Content.ReadAsStringAsync(); // lấy dữ liệu trả về định dạng json.
                    Console.WriteLine(resultContent);
                    // ép kiểu dữ liệu trả về thành danh sách post.
                    list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(resultContent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }

    }
}
