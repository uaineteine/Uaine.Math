﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uaine.Math.Equations;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] x = new float[] { 1, 2, 3 };
            float[] y = new float[] { 2, 4, 6 };

            Linear eq = new Linear(0, 0);
            eq.SolveLeastSquares(x, y);
            float[] c = eq.Coefficients;
            Console.WriteLine(c[0]);
            Console.WriteLine(c[1]);

            Console.Read();
        }
    }
}
