using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Filter
{
    class Filter
    {
        private Bitmap bmp_from = null, bmp_to = null;

        object obj = new object();

        public void Load_Picture(string file_in)
        {
            if (file_in != "")
                try
                {
                    bmp_from = (Bitmap)Image.FromFile(file_in);
                    Console.WriteLine("Изображение для обработки загружено");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
        }

        public void Filter_And_Save(string file_out)
        {
            if (bmp_from != null)
            {
                if (bmp_from.Width < 3 || bmp_from.Height < 3) Console.WriteLine("Изображение для обработки слишком маленькое");
                else
                {
                    Console.WriteLine("Идет обработка. Подождите...");
                    bmp_to = bmp_from.Clone(new Rectangle(0, 0, bmp_from.Width, bmp_from.Height), bmp_from.PixelFormat);

                    List<byte[]> R = new List<byte[]>();
                    List<byte[]> G = new List<byte[]>();
                    List<byte[]> B = new List<byte[]>();
                    List<int[]> XY = new List<int[]>();

                    for (int i = 1; i < bmp_from.Width - 1; i++)
                        for (int j = 1; j < bmp_from.Height - 1; j++)
                        {
                            byte[] r = new byte[9], g = new byte[9], b = new byte[9]; int[] xy = new int[2];
                            r[0] = bmp_from.GetPixel(i - 1, j - 1).R; r[1] = bmp_from.GetPixel(i - 1, j).R; r[2] = bmp_from.GetPixel(i - 1, j + 1).R;
                            r[3] = bmp_from.GetPixel(i, j - 1).R; r[4] = bmp_from.GetPixel(i, j).R; r[5] = bmp_from.GetPixel(i, j + 1).R;
                            r[6] = bmp_from.GetPixel(i + 1, j - 1).R; r[7] = bmp_from.GetPixel(i + 1, j).R; r[8] = bmp_from.GetPixel(i + 1, j + 1).R;

                            g[0] = bmp_from.GetPixel(i - 1, j - 1).G; g[1] = bmp_from.GetPixel(i - 1, j).G; g[2] = bmp_from.GetPixel(i - 1, j + 1).G;
                            g[3] = bmp_from.GetPixel(i, j - 1).G; g[4] = bmp_from.GetPixel(i, j).G; g[5] = bmp_from.GetPixel(i, j + 1).G;
                            g[6] = bmp_from.GetPixel(i + 1, j - 1).G; g[7] = bmp_from.GetPixel(i + 1, j).G; g[8] = bmp_from.GetPixel(i + 1, j + 1).G;

                            b[0] = bmp_from.GetPixel(i - 1, j - 1).B; b[1] = bmp_from.GetPixel(i - 1, j).B; b[2] = bmp_from.GetPixel(i - 1, j + 1).B;
                            b[3] = bmp_from.GetPixel(i, j - 1).B; b[4] = bmp_from.GetPixel(i, j).B; b[5] = bmp_from.GetPixel(i, j + 1).B;
                            b[6] = bmp_from.GetPixel(i + 1, j - 1).B; b[7] = bmp_from.GetPixel(i + 1, j).B; b[8] = bmp_from.GetPixel(i + 1, j + 1).B;
                            
                            xy[0] = i; xy[1] = j; XY.Add(xy);
                            R.Add(r); B.Add(b); G.Add(g);
                        }
                    
                    Parallel.For(0,R.Count, i =>
                        {
                            NewColor(XY[i][0], XY[i][1], R[i], G[i], B[i]);
                        });
                }
                Save_To_File(file_out);
            }
        }

        private void Save_To_File(string file_out)
        {
            try
            {
                if (bmp_to != null)
                {
                    bmp_to.Save(file_out);
                    Console.WriteLine("Новое изображение сохранено");
                    bmp_from.Dispose();
                    bmp_to.Dispose();
                }
                else
                    if (bmp_from != null)
                    {
                        bmp_from.Save(file_out);
                        Console.WriteLine("Исходное изображение скопировано с новым именем");
                        bmp_from.Dispose();
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void NewColor(int x, int y, byte[] R, byte[] G, byte[] B)
        {
            Array.Sort(R);
            Array.Sort(G);
            Array.Sort(B);
            lock (obj)
            {
                bmp_to.SetPixel(x, y, Color.FromArgb(R[4],G[4],B[4]));
            }
        }
    }
}
