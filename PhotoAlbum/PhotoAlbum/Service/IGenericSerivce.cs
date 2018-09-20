using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.Service
{
    public interface IGenericSerivce
    {
        Task<T> GetResponse<T>(string path);
        Task<string> GetWebRequestResultAsync(string path);

    }
}
