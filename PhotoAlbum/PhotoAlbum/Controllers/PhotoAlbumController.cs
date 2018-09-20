using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.DataType;
using PhotoAlbum.Models;
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

        public async Task<IActionResult> Get()
        {
            return Ok(await PhotoAlbumService.GetTable());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PageRequest request)
        {
            var response = await PhotoAlbumService.GetPhotoAlbum();
            var PageResponse = PageResponse<PhotoAlbum.DataType.PhotoAlbumType>.ReturnPageResponse(response, request.Page, request.PageSize);
            return Ok(PageResponse);
        }
    }
}
