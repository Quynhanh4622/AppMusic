using AppMusic.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AppMusic.Services 
{
    public class AccountService
    {
        private static string ApiBaseUrl = "https://music-i-like.herokuapp.com";
        private static string ApiLoginPath = "/api/v1/accounts/authentication";
        private static string ApiRegisterPath = "/api/v1/accounts";
        private static string ApiDataType = "application/json";
        public async Task<bool> Login(Account account)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(account);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await httpClient.PostAsync(ApiLoginPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error!";
                dialog.Content = $"{e.Message}";
                dialog.CloseButtonText = "OK";
                await dialog.ShowAsync();
                return false;
            }
        }

        public async Task<Account> GetProfile(string accessToken)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    var result = await httpClient.GetAsync(ApiRegisterPath);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    var account = Newtonsoft.Json.JsonConvert.DeserializeObject<Account>(resultContent);
                    Debug.WriteLine(resultContent);
                    return account;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> Register(Account account)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(account);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await httpClient.PostAsync(ApiRegisterPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error!";
                dialog.Content = $"{e.Message}";
                dialog.CloseButtonText = "OK";
                await dialog.ShowAsync();
                return false;
            }
        }
        public async Task<bool> Login(string loginEmail, string loginPassword)
        {
            try
            {
                using(var client = new HttpClient())
                {
                    Debug.WriteLine($"Email: '{loginEmail}'");
                    Debug.WriteLine($"Password: '{loginPassword}'");
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var loginInformation = new
                    {
                        email = loginEmail,
                        password = loginPassword
                    };
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject((loginInformation));
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    Debug.WriteLine(contentToSend.ToString());
                    var result = await client.PostAsync(ApiLoginPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine(resultContent);
                    return true;
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}