namespace Uaine.Math.Equations
{
    public static class Pythag
    {
        public static double Pythag2D(double  a, double  b) //return c
        {
            return System.Math.Sqrt(a * a + b * b);
        }
        public static double Pythag3D(double a, double b, double c) //return c
        {
            return System.Math.Sqrt(a * a + b * b + c * c);
        }
        public static double PythagNDim(double[] values, int n) //return c
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += values[i]*values[i];
            }
            return System.Math.Sqrt(sum);
        }
    }
}
