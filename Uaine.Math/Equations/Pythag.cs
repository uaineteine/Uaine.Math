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
    }
}
