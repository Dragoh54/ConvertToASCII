﻿using System.Drawing;
using System.Drawing.Imaging;

namespace ImageToASCII.Extensions;

public static class BitmapExtension
{
    public static void ToGrayscale(this Bitmap bitmap)
    {
        for (int y = 0; y < bitmap.Height; y++)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                var pixel = bitmap.GetPixel(x, y);
                int avg = (pixel.R + pixel.G + pixel.B) / 3;
                bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, avg, avg, avg));
            }
        }
    }
}