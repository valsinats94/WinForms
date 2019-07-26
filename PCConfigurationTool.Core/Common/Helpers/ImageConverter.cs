﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace PCConfigurationTool.Core.Common.Helpers
{
    public class ImageConverter
    {

        public static byte[] CopyImageToByteArray(Image theImage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        public static Image GetImageFromByteArray(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
