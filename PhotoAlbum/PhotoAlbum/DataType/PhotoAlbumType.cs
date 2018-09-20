using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DataType
{
    public class PhotoAlbumType
    {
        public int AlbumId { get; set; }
        public int PhotoId { get; set; }
        public string Title { get; set; }
        public string AlbumName { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }

        internal JQDataTable ConvertToTable(JQDataTable table)
        {
            List<string> tableRow = new List<string>
            {
                this.AlbumId.ToString(),
                this.PhotoId.ToString(),
                this.Title,
                this.AlbumName,
                this.ThumbnailUrl,
                this.Url,
                this.UserId.ToString()
            };

            table.Data.Add(tableRow);
            return table;
        }
    }
}
