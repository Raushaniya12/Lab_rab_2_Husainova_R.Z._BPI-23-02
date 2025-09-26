using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

public static class BitmapConverter
{
    public static BitmapImage ToBitmapImage(Bitmap bitmap)
    {
        if (bitmap == null) return null;

        using var memory = new MemoryStream();
        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
        memory.Position = 0;

        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();

        return bitmapImage;
    }
}