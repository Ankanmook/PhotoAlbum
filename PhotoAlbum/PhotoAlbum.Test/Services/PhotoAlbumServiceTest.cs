using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DataType;
using PhotoAlbum.Service;

namespace PhotoAlbum.Test.Services
{
    public class PhotoAlbumServiceTest
    {
        [Test]
        public async Task GetPhotoAlbum()
        {
            IGenericSerivce genericSerivce = new GenericService();

            //Get Photo
            var photos = await genericSerivce.GetResponse<List<Photo>>(Settings.Settings.PhotoAPI);
            //Get Album
            var albums = await genericSerivce.GetResponse<List<Album>>(Settings.Settings.AlbumAPI);

            List<PhotoAlbumType> photoAlbums = new List<PhotoAlbumType>();

            foreach (var album in albums)
            {
                foreach (var photo in photos.Where(p => p.AlbumId == album.Id))
                {
                    PhotoAlbumType photoAlbum = new PhotoAlbumType()
                    {
                        AlbumId = album.Id,
                        AlbumName = album.Title,
                        UserId = album.UserId,

                        PhotoId = photo.Id,
                        Title = photo.Title,
                        Url = photo.Url,
                        ThumbnailUrl = photo.ThumbnailUrl
                    };

                    photoAlbums.Add(photoAlbum);
                }
            }

            Assert.IsTrue(photoAlbums.Count > 0);

            //Extract Photo Album

            Assert.IsTrue(photoAlbums.Count() > 0);
        }

        public async Task GetPhotoAlbumTest()
        {
            PhotoAlbumService photoAlbumService = new PhotoAlbumService(new GenericService());
            var photoAlbums = await photoAlbumService.GetPhotoAlbum();
            Assert.IsTrue(photoAlbums.Count > 0);
        }

        public async Task GetTable()
        {
            PhotoAlbumService photoAlbumService = new PhotoAlbumService(new GenericService());
            var jqueryTable = await photoAlbumService.GetTable();
            Assert.IsTrue(jqueryTable.Data.Count > 0);
        }
    }
}
