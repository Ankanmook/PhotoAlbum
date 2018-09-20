using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PhotoAlbum.Controllers;
using PhotoAlbum.DataType;
using PhotoAlbum.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Test.Controller
{
    class PhotoAlbumControllerTest
    {
        PhotoAlbumController PhotoAlbumController { get; set; }

        Mock<IPhotoAlbumService> MockPhotoAlbumService { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            IGenericSerivce GenericService = new GenericService();
            IPhotoAlbumService PhotoAlbumService = new PhotoAlbumService(GenericService);

            PhotoAlbumController = new PhotoAlbumController(PhotoAlbumService);

            MockPhotoAlbumService = new Mock<IPhotoAlbumService>();
        }

        [Test]
        public void IndexUnitTest()
        {
            var viewResult = PhotoAlbumController.Index();

            Assert.IsInstanceOf<ViewResult>(viewResult);
        }

        [Test]
        public async Task IntegrationTest()
        {

            var response = await PhotoAlbumController.Get();
            var okResult = response as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual(200, okResult.StatusCode);
        }


        [Test]
        public async Task GetUnitTest()
        {
           

            JQDataTable fakeResult = new JQDataTable();

            MockPhotoAlbumService.Setup(m => m.GetTable()).Returns(Task.FromResult(fakeResult));
            PhotoAlbumController = new PhotoAlbumController(MockPhotoAlbumService.Object);

            var response = await PhotoAlbumController.Get();
            var okResult = response as OkObjectResult;

            Assert.IsNotNull(okResult.Value);
            MockPhotoAlbumService.Verify(m => m.GetTable(), Times.Once);

        }
    }
}
