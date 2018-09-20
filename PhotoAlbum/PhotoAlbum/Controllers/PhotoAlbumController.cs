using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Controllers
{
    public class PhotoAlbumController : Controller
    {
        public PhotoAlbumController(IPhotoAlbumService PhotoAlbumService)
        {
            this.PhotoAlbumService = PhotoAlbumService;
        }

        public IPhotoAlbumService PhotoAlbumService { get; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
        {
            return Json(PhotoAlbumService.GetTable());
        }

    }
}
