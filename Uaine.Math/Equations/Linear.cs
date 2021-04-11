using System;
using System.Collections.Generic;
using System.Text;

namespace Uaine.Math.Equations
{
    public class Linear : Polynomial
    {
        public Linear(float a, float b) : base(new List<float>(new float[] { a, b }), 2)
        {
        }
    }
}
