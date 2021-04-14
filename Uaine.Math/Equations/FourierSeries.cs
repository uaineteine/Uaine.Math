using System.Collections.Generic;

namespace Uaine.Math.Equations
{
    public class FourierSeries : Function
    {
        protected List<float> ak;
        protected List<float> bk;
        public float[] Ak { get => ak.ToArray(); }
        public float[] Bk { get => ak.ToArray(); }
        protected int _deg = 1;
        public int Degree { get => _deg; }

        public FourierSeries(List<float> coefficientsA, List<float> coefficientsB, int deg)
        {
            this.ak = coefficientsA;
            this.bk = coefficientsB;
            _deg = deg;
        }
        public FourierSeries(int deg)
        {
            this.ak = new List<float>();
            this.bk = new List<float>();
            for (int i = 0; i < deg + 1; i++)
            {
                this.ak.Add(0);
                this.bk.Add(0);
            }
            _deg = deg;
        }

        public override float f(float x)
        {
            float sum = 0;
            for (int i = 0; i < _deg; i++)
            {
                sum += (float)(ak[i] * Ka(i, x) + bk[i] * Kb(i, x));
            }
            return sum;
        }

        //Jai and Jbi are the same
        protected static double Ka(int k, float xi)
        {
            return System.Math.Sin(phi(k, xi));
        }

        protected static double Kb(int k, float xi)
        {
            return System.Math.Cos(phi(k, xi));
        }

        public static double phi(int k, float xi)
        {
            return 2 * System.Math.PI * k * xi;
        }

        public override void SolveLeastSquares(float[] x, float[] y)
        {
            int dd = 2 * _deg;
            int n = x.Length;

            double[,] a = new double[dd, dd];
            for (int i = 0; i < _deg; i++)
            {
                for (int j = 0; j < _deg; j++)
                {
                    a[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        double Jai = Ka(i, x[k]);
                        double Kai = Ka(j, x[k]);
                        a[i, j] += Jai * Kai;
                    }
                }
                for (int jj = 0; jj < _deg; jj++)
                {
                    int j = jj + _deg;
                    a[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        double Jai = Ka(i, x[k]);
                        double Kbi = Kb(jj, x[k]);
                        a[i, j] += Jai * Kbi;
                    }
                }
            }

            for (int i = 0; i < _deg; i++)
            {
                int ii = i + _deg;
                for (int j = 0; j < _deg; j++)
                {
                    a[ii, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        double Jbi = Kb(i, x[k]);
                        double Kai = Ka(j, x[k]);
                        a[i, j] += Jbi * Kai;
                    }
                }
                for (int jj = 0; jj < _deg; jj++)
                {
                    int j = jj + _deg;
                    a[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        double Jbi = Kb(i, x[k]);
                        double Kbi = Kb(jj, x[k]);
                        a[i, j] += Jbi * Kbi;
                    }
                }
            }
            var A = MathNet.Numerics.LinearAlgebra.CreateMatrix.DenseOfArray(a);

            double[] b = new double[dd];
            for (int i = 0; i < _deg; i++)
            {
                int j = i + _deg;
                b[i] = 0;
                b[j] = 0;
                for (int k = 0; k < n; k++)
                {
                    double Jai = Ka(i, x[k]);
                    b[i] += Jai*y[k];
                    double Jbi = Kb(i, x[k]);
                    b[j] += Jbi * y[k];
                }
            }
            var B = MathNet.Numerics.LinearAlgebra.CreateVector.Dense(b);

            //solve
            var X = A.Solve(B);
            for (int i = 0; i < _deg; i++)
            {
                ak[i] = (float)X[i];
                int j = i + _deg;
                bk[i[ = (float)X[j];

            }
        }
    }
}
