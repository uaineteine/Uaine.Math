using System;
using System.Collections.Generic;
using System.Text;
using Uaine.Math.Equations;

namespace Uaine.Math.Interpolation
{
    public static class LinInterpolation
    {
        public static float UnitInterpolation(float xi, float[] yvals)
        {
            Linear eq = new Linear(0, 0);
            eq.SolveLeastSquares(new float[] { 0, 1 }, yvals);
            return eq.f(xi);
        }
    }
}
