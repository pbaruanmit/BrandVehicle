using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShowroomWinForm1
{
    public static class ServiceClient
    {
        internal async static Task<List<string>> GetBrandNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>(
                    await lcHttpClient.GetStringAsync("http://localhost:60064/api/showroom/GetBrandNames/"));
        }
        internal async static Task<clsBrand> GetBrandAsync(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient()) return JsonConvert.DeserializeObject<clsBrand>
             (await lcHttpClient.GetStringAsync("http://localhost:60064/api/showroom/GetArtist?Name=" + prArtistName));
        }
        internal async static Task<clsVehicle> GetVehicleAsync(string prArtistName)
        {
            using (HttpClient lcHttpClient = new HttpClient()) return JsonConvert.DeserializeObject<clsVehicle>
             (await lcHttpClient.GetStringAsync("http://localhost:60064/api/showroom/GetVehicle?Name=" + prArtistName));
        }
        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest) { using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl)) using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json")) using (HttpClient lcHttpClient = new HttpClient()) { HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage); return await lcRespMessage.Content.ReadAsStringAsync(); } }

        internal async static Task<string> InsertArtistAsync(clsBrand artist)
        {
            return await InsertOrUpdateAsync(artist, "http://localhost:60064/api/showroom/PutArtist", "PUT");
        }

        internal async static Task<string> UpdateArtistAsync(clsBrand artist)
        {
            return await InsertOrUpdateAsync(artist, "http://localhost:60064/api/showroom/PutArtist", "PUT");
        }

        internal async static Task<string> DeleteArtist(object lcKey)
        {
            throw new NotImplementedException();
        }
    }
    
}
