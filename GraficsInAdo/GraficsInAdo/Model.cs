using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace GraficsInAdo
{
    class Model
    {
        public Model()
        {

        }
        
        public byte[] CreateCopy(string imagepath)
        {
            Image img = new Bitmap(imagepath);

            int maxWidth = 300;
            int maxHeight = 300;

            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;

            double ratio = Math.Min(ratioX,ratioY);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            Image newim = new Bitmap(newWidth,newHeight);


            Graphics g = Graphics.FromImage(newim);

            g.DrawImage(img,0,0,newWidth,newHeight);

            MemoryStream ms = new MemoryStream();

            newim.Save(ms,ImageFormat.Jpeg);
            ms.Flush();
            ms.Seek(0,SeekOrigin.Begin);

            BinaryReader reader = new BinaryReader(ms);
            return reader.ReadBytes((int)ms.Length);
        }
    }
}
