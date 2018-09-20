using PhotoAlbum.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Service
{
    public interface IPhotoAlbumService
    {
        Task<List<PhotoAlbumType>> GetPhotoAlbum();
        Task<JQDataTable> GetTable();
    }
}
