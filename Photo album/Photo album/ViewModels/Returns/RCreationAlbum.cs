using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_album
{
    /// <summary>
    /// Результат работы окна <see cref="Creation_new_photo_album"/>
    /// </summary>
    class RCreationAlbum : IData
    {
        public string AlbumName { get; set; }

        public RCreationAlbum(string name)
        {
            AlbumName = name;
        }
    }
}
