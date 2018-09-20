using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DataType;
using PhotoAlbum.Service;
using Moq;

namespace PhotoAlbum.Test.Services
{
    public class PhotoAlbumServiceTest
    {

        Mock<IGenericSerivce> MockGenericSerivce { get; set; }

        IGenericSerivce GenericSerivce { get; set; }

        PhotoAlbumService PhotoAlbumService { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            MockGenericSerivce = new Mock<IGenericSerivce>();
            GenericSerivce = new GenericService();
            PhotoAlbumService = new PhotoAlbumService(new GenericService());
        }

        [Test]
        public async Task GetPhotoAlbumIntegrationTest()
        {
            

            //Get Photo
            var photos = await GenericSerivce.GetResponse<List<Photo>>(Settings.Settings.PhotoAPI);
            //Get Album
            var albums = await GenericSerivce.GetResponse<List<Album>>(Settings.Settings.AlbumAPI);

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
            var photoAlbums = await PhotoAlbumService.GetPhotoAlbum();
            Assert.IsTrue(photoAlbums.Count > 0);
        }

        public async Task GetTableTest()
        {
            var jqueryTable = await PhotoAlbumService.GetTable();
            Assert.IsTrue(jqueryTable.Data.Count > 0);
        }

        public async Task GetPhotoAlbumUnitTest()
        {
            List<Photo> fakePhotos = new List<Photo>();
            List<Album> fakeAlbums = new List<Album>();

            MockGenericSerivce.Setup(m => m.GetResponse<List<Photo>>(Settings.Settings.PhotoAPI)).Returns(Task.FromResult(fakePhotos)); ;
            MockGenericSerivce.Setup(m => m.GetResponse<List<Album>>(Settings.Settings.AlbumAPI)).Returns(Task.FromResult(fakeAlbums)); ;

            PhotoAlbumService = new PhotoAlbumService(MockGenericSerivce.Object);
            var photoAlbums = await PhotoAlbumService.GetPhotoAlbum();

            MockGenericSerivce.Verify(m => m.GetResponse<List<Photo>>(Settings.Settings.PhotoAPI), Times.Once);
            MockGenericSerivce.Verify(m => m.GetResponse<List<Album>>(Settings.Settings.AlbumAPI), Times.Once);
        }

    }
}
