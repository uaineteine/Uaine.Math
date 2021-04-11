using System;
using System.Collections.Generic;

namespace Uaine.Math.Equations
{
    public abstract class Polynomial : Function
    {
        protected List<float> coefficients;
        int _deg = 1;
        public int Degree { get => _deg; }

        public Polynomial(List<float> coefficients, int deg)
        {
            this.coefficients = coefficients;
            _deg = deg;
        }

        public override float f(float x)
        {
            float sum = coefficients[coefficients.Count - 1];
            for (int i = 0; i < coefficients.Count - 1; i++)
            {
                int pow = _deg - i;
                sum += (float)(coefficients[i] * System.Math.Pow(x, pow));
            }
            return sum;
        }

        public abstract void Solve(float[] x, float[] y);
        public abstract void SolveLeastSquares(float[] x, float[] y);
    }
}
