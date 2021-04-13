using System;
using System.Collections.Generic;
using System.Text;
namespace Uaine.Math.Equations
{
    public class Linear : Polynomial
    {
        public Linear(float a, float b) : base(new List<float>(new float[] { a, b }), 1)
        {
        }

        public override void SolveLeastSquares(float[] x, float[] y)
        {
            double a12 = x[0] + x[1]; //sumxi
            double a21 = a12;
            double a11 = x[0] * x[0] + x[1] * x[1];
            double a22 = x.Length;
            var A = MathNet.Numerics.LinearAlgebra.CreateMatrix.DenseOfArray(
                new double[,]
                {
                    { a11, a12 },
                    { a21, a22 }
                });
            double b2 = y[0] + y[1];
            double b1 = y[0] * x[0] + y[1] * x[1];
            var b = MathNet.Numerics.LinearAlgebra.CreateVector.Dense(
                new double[]
                {
                    b1, b2
                });

            //solve
            var X = A.Solve(b);
            for (int i = 0; i < _deg + 1; i++)
                coefficients[i] = (float)X[i];
        }
    }
}
