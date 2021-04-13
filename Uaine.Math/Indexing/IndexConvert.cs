using System;
using System.Collections.Generic;
using System.Text;

namespace Uaine.Math.Indexing
{
    public static class IndexConvert
    {
        public static int To1D(int x, int y, int w)
        {
            int index = y * w;
            return index + x;
        }
    }
}
