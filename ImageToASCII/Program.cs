using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using ImageToASCII.ASCIIConvertions;
using ImageToASCII.Extensions;
using ImageToASCII.ImageConvertions;

namespace ImageToASCII;

class Program
{
    static void Main(string[] args)
    {
        string currentDir = AppContext.BaseDirectory;
        string projectRoot = Directory.GetParent(currentDir).Parent.Parent.Parent.FullName;
        string imagePath = Path.Combine(projectRoot, "Images", "testImage.jpg");

        if (File.Exists(imagePath))
        {
            var bitmap = new Bitmap(imagePath);
            bitmap = ImageRefactors.GetReSizedImage(bitmap, 0.5f);
            //bitmap = ImageRefactors.GetReSizedImage(bitmap, 1440 / 4, 2560 / 4);

            bitmap.ToGrayscale();

            var converter = new BitmapToASCIIConverter(bitmap);
            var rows = converter.Convert();

            string filePath = Path.Combine(projectRoot, "Images", "output.txt");
            
            try
            {
                File.WriteAllLines(filePath, rows.Select(row => new string(row)));

                Console.WriteLine($"Saved: {Path.GetFullPath(filePath)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

