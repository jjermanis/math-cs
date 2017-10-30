using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_cs
{
    public static partial class MathExt
    {
        public static IEnumerable<int> FibonacciNumbers()
        {
            yield return 1;
            yield return 1;
            int x = 1;
            int y = 1;
            // This will overflow as the series exceeds Int32.MaxValue.
            checked
            {
                while (true)
                {
                    var z = x + y;
                    yield return z;
                    x = y;
                    y = z;
                }
            }
        }
    }
}
