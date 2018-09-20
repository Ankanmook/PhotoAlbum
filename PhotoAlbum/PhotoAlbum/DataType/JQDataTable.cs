using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbum.DataType
{
    public class JQDataTable
    {
        public JQDataTable()
        {
            Data = new List<List<string>>();
        }
        public List<List<string>> Data { get; set; }
    }
}
