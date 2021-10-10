using System;
using System.Collections.Generic;
using System.Text;

namespace Uaine.Math.Indexing
{
    public static class IndexConvert2D
    {
        public static int To1D(int x, int y, int w)
        {
            int index = y * w;
            return index + x;
        }
        public static void To2D(int ind, int w, out int x, out int y)
        {
            y = ind / w;
            x = ind % w;
        }
    }
}