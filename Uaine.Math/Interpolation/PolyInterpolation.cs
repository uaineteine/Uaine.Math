using System;
using System.Collections.Generic;
using System.Text;
using Uaine.Math.Equations;

namespace Uaine.Math.Interpolation
{
    public class PolyInterpolation : Interpolator
    {
        public PolyInterpolation(int deg) : base(new Polynomial(deg))
        {

        }
    }
}
