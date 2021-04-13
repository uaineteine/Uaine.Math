using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uaine.Math.Equations;
using Uaine.Math.Interpolation;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] x = new float[] { 1, 2, 3 };
            float[] y = new float[] { 2, 4, 6 };

            Polynomial eq = new Polynomial(2);
            eq.SolveLeastSquares(x, y);
            float[] c = eq.Coefficients;
            Console.WriteLine(c[0]);
            Console.WriteLine(c[1]);
            Console.WriteLine(c[2]);

            Console.WriteLine();
            y = new float[] { 0, 2};
            PolyInterpolation intp = new PolyInterpolation(1);
            float ynew = intp.UnitInterpolation(0.5f, y);
            Console.WriteLine(ynew);

            Console.Read();
        }
    }
}
