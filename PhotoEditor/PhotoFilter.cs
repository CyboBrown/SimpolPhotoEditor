using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace PhotoEditor
{
    public class ConvMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;
        public void SetAll(int nVal)
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
        }
    }

    public class PhotoFilter
    {
        // Note that the following codes are not my own

        public static bool grayscale(Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);

                        p += 3;  ///very good....
					}
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        public static bool sepia(Bitmap b)
        {
            return true;
        }

        public static bool invert(Bitmap b)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            return true;
        }

        public static bool flip(Bitmap b, bool bHorz, bool bVert)
        {
            Point[,] ptFlip = new Point[b.Width, b.Height];

            int nWidth = b.Width;
            int nHeight = b.Height;

            for (int x = 0; x < nWidth; ++x)
                for (int y = 0; y < nHeight; ++y)
                {
                    ptFlip[x, y].X = (bHorz) ? nWidth - (x + 1) : x;
                    ptFlip[x, y].Y = (bVert) ? nHeight - (y + 1) : y;
                }

            OffsetFilterAbs(b, ptFlip);

            return true;
        }


        public static bool flip_vertically(Bitmap b)
        {
            return flip(b, true, false);
        }

        public static bool flip_horizontally(Bitmap b)
        {
            return flip(b, false, true);
        }

        // Unused

        public static bool edge_detection(Bitmap b)
        {
            Bitmap bmTemp = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmData2 = bmTemp.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr Scan02 = bmData2.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* p2 = (byte*)(void*)Scan02;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                int nPixel = 0;

                p += stride;
                p2 += stride;

                for (int y = 1; y < b.Height - 1; ++y)
                {
                    p += 9;
                    p2 += 9;

                    for (int x = 9; x < nWidth - 9; ++x)
                    {
                        nPixel = ((p2 + stride - 9)[0] +
                            (p2 + stride - 6)[0] +
                            (p2 + stride - 3)[0] +
                            (p2 + stride)[0] +
                            (p2 + stride + 3)[0] +
                            (p2 + stride + 6)[0] +
                            (p2 + stride + 9)[0] -
                            (p2 - stride - 9)[0] -
                            (p2 - stride - 6)[0] -
                            (p2 - stride - 3)[0] -
                            (p2 - stride)[0] -
                            (p2 - stride + 3)[0] -
                            (p2 - stride + 6)[0] -
                            (p2 - stride + 9)[0]);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        (p + stride)[0] = (byte)nPixel;

                        ++p;
                        ++p2;
                    }

                    p += 9 + nOffset;
                    p2 += 9 + nOffset;
                }
            }

            b.UnlockBits(bmData);
            bmTemp.UnlockBits(bmData2);

            return true;
        }

        // Helper

        public static bool OffsetFilterAbs(Bitmap b, Point[,] offset)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int scanline = bmData.Stride;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;

                int nOffset = bmData.Stride - b.Width * 3;
                int nWidth = b.Width;
                int nHeight = b.Height;

                int xOffset, yOffset;

                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        xOffset = offset[x, y].X;
                        yOffset = offset[x, y].Y;

                        if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
                        {
                            p[0] = pSrc[(yOffset * scanline) + (xOffset * 3)];
                            p[1] = pSrc[(yOffset * scanline) + (xOffset * 3) + 1];
                            p[2] = pSrc[(yOffset * scanline) + (xOffset * 3) + 2];
                        }

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return true;
        }

    }
}