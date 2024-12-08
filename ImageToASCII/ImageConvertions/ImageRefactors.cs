namespace ImageToASCII.ImageConvertions;

public static class ImageRefactors
{
    public static Bitmap GetReSizedImage(Bitmap bitmap, float scaleFactor, float aspectRatio = 0.5f)
    {
        if (scaleFactor <= 0 || scaleFactor > 1)
            throw new ArgumentException("Scale factor must be between 0 and 1.", nameof(scaleFactor));

        int newWidth = (int)(bitmap.Width * scaleFactor);
        int newHeight = (int)(bitmap.Height * scaleFactor * aspectRatio);

        var resizedImage = new Bitmap(newWidth, newHeight);

        using (var graphics = Graphics.FromImage(resizedImage))
        {
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            graphics.DrawImage(bitmap, 0, 0, newWidth, newHeight);
            graphics.Dispose();
        }

        return resizedImage;
    }
    
    public static Bitmap GetReSizedImage(Bitmap originalImage, int maxWidth, int maxHeight, float aspectRatio = 0.5f)
    {
        if (maxWidth <= 0 || maxHeight <= 0)
            throw new ArgumentException("Maximum width and height must be greater than 0.");
        
        float widthRatio = (float)maxWidth / originalImage.Width;
        float heightRatio = maxHeight / (originalImage.Height * aspectRatio);
        
        float scaleFactor = Math.Min(widthRatio, heightRatio);
        
        int newWidth = (int)(originalImage.Width * scaleFactor);
        int newHeight = (int)(originalImage.Height * scaleFactor * aspectRatio);
        
        var resizedImage = new Bitmap(newWidth, newHeight);

        using (var graphics = Graphics.FromImage(resizedImage))
        {
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            graphics.Dispose();
        }

        return resizedImage;
    }
}