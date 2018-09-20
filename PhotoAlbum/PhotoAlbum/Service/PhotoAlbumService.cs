using PhotoAlbum.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Service
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        IGenericSerivce GenericSerivce;

        public PhotoAlbumService(IGenericSerivce GenericSerivce)
        {
            this.GenericSerivce = GenericSerivce;
        }

        public async Task<List<PhotoAlbumType>> GetPhotoAlbum()
        {
            List<Photo> photos = await GenericSerivce.GetResponse<List<Photo>>(Settings.Settings.PhotoAPI);
            List<Album> albums = await GenericSerivce.GetResponse<List<Album>>(Settings.Settings.AlbumAPI);

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

            return photoAlbums;
        }

        public async Task<JQDataTable> GetTable()
        {
            List<PhotoAlbumType> photoAlbums = await GetPhotoAlbum();
            JQDataTable jqueryTable = new JQDataTable();

            foreach (PhotoAlbumType photoAlbum in photoAlbums)
            {
                photoAlbum.ConvertToTable(jqueryTable);
            }
            return jqueryTable;
        }
    }
}
