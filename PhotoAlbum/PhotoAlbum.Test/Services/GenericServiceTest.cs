using NUnit.Framework;
using PhotoAlbum.DataType;
using PhotoAlbum.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Test.Services
{
    public class GenericServiceTest
    {
        [Test]
        public async Task Get()
        {
            IGenericSerivce genericSerivce = new GenericService();

            var photos = await genericSerivce.GetResponse<List<Photo>>(Settings.Settings.PhotoAPI);
            var albums = await genericSerivce.GetResponse<List<Album>>(Settings.Settings.AlbumAPI);

            Assert.IsTrue(photos.Count > 0);
            Assert.IsTrue(albums.Count > 0);

        }
    }
}
