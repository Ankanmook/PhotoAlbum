using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Test.Services
{
    public class AlbumSerivceTest
    {
        [Test]
        public async Task GetAlbum()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            using (HttpClient client = new HttpClient())
            {
                response = await client.GetAsync(Settings.Settings.AlbumAPI);
            }


            Assert.IsTrue(response.IsSuccessStatusCode == true);
        }
    }
}
