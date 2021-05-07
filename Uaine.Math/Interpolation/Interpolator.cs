using System;
using System.Collections.Generic;
using System.Text;
using Uaine.Math.Equations;

namespace Uaine.Math.Interpolation
{
    public class Interpolator
    {
        protected Function eq;
        public Interpolator(Function equation)
        {
            eq = equation;
        }

        public float UnitInterpolation(float xi, float[] yvals)
        {
            eq.SolveLeastSquares(new float[] { 0, 1 }, yvals);
            return eq.f(xi);
        }

        public float Interpolation(float x, float[] xi, float[] yi)
        {
            eq.SolveLeastSquares(xi, yi);
            return eq.f(x);
        }
    }
}
