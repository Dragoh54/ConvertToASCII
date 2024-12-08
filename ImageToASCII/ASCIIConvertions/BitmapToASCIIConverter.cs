namespace ImageToASCII.ASCIIConvertions;

public class BitmapToASCIIConverter
{
    private readonly Bitmap _bitmap;

    private const string ASCII_TABLE =
        //"`.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@";
        "@&%QWN0gB$#DRm8HXKAUbOGpV4d9h6PkwqS2]ayjxY5Z[oenult13IfC{iF|7J)vTLs?z/*cr!+<>;=^,:'-.` ";
    //private char[] ASCII_TABLE = { '@', '#', 'S', '%', '=', '+', '*', ':', '-', '.', ' ' };
    
    public BitmapToASCIIConverter(Bitmap bitmap)
    {
        _bitmap = bitmap;
    }

    public char[][] Convert()
    {
        var result = new char[_bitmap.Height][];

        for (int y = 0; y < _bitmap.Height; y++)
        {
            result[y] = new char[_bitmap.Width];    
            for (int x = 0; x < _bitmap.Width; x++)
            {
                 int mapIndex = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, ASCII_TABLE.Length - 1);
                 result[y][x] = ASCII_TABLE[mapIndex];
            }
        }

        return result;
    }

    private float Map(float valueToMap, float start1, float stop1, float start2, float stop2)
    {
        return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
    }
}