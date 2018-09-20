using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Service
{
    public class GenericService : IGenericSerivce
    {
        public async Task<T> GetResponse<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(await GetWebRequestResultAsync(path));
        }

        public async Task<string> GetWebRequestResultAsync(string path)
        {
            string result;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(path);
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

    }
}
