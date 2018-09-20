using Newtonsoft.Json;
using NUnit.Framework;
using PhotoAlbum.DataType;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Test.Services
{   
    class PhotoServiceTest
    {
        [Test]
        public async Task GetPhoto()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            string result; 

            using (HttpClient client = new HttpClient())
            {
                response = await client.GetAsync(Settings.Settings.PhotoAPI);

                result = await response.Content.ReadAsStringAsync();
            }

            Assert.IsTrue(response.IsSuccessStatusCode == true);
            Assert.IsTrue(string.IsNullOrWhiteSpace(result) == false);

            
            var photo = JsonConvert.DeserializeObject<List<Photo>>(result);

            Assert.IsTrue(photo.Count > 0);


            
        }

    }
}
