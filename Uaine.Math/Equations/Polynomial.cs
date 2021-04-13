using System;
using System.Collections.Generic;

namespace Uaine.Math.Equations
{
    public class Polynomial : Function
    {
        protected List<float> coefficients;
        public float[] Coefficients { get => coefficients.ToArray(); }
        protected int _deg = 1;
        public int Degree { get => _deg; }

        public Polynomial(List<float> coefficients, int deg)
        {
            this.coefficients = coefficients;
            _deg = deg;
        }
        public Polynomial(int deg)
        {
            this.coefficients = new List<float>();
            for (int i = 0; i < deg+1; i++)
                this.coefficients.Add(0);
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

        public void SolveLeastSquares(float[] x, float[] y)
        {
            int n = _deg + 1;
            int nn = 2 * _deg;
            double ann = x.Length;

            double[,] a = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == j && i == _deg)
                    {
                        a[i, j] = n;
                    }
                    else
                    {
                        a[i, j] = 0;
                        for (int k = 0; k < ann; k++)
                            a[i, j] += System.Math.Pow(x[k], nn - j - i);
                    }
                }
            var A = MathNet.Numerics.LinearAlgebra.CreateMatrix.DenseOfArray(a);

            double[] b = new double[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = 0;
                if (i == _deg)
                {
                    for (int k = 0; k < ann; k++)
                        b[i] += y[k];
                }
                else
                {
                    for (int k = 0; k < ann; k++)
                        b[i] += y[k] * System.Math.Pow(x[k], Degree - i);
                }
            }
            var B = MathNet.Numerics.LinearAlgebra.CreateVector.Dense(b);

            //solve
            var X = A.Solve(B);
            for (int i = 0; i < n; i++)
                coefficients[i] = (float)X[i];
        }
    }
}
