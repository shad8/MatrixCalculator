using System;
using System.Globalization;
using System.Linq;

namespace MatrixCalculator
{
  public static class MyStringExtensions
  {
    public static double[] ConvertStringToDoubleArray(this string value)
    {
      string[] strings = value.Split(';');
      double[] doubles = strings.Select(x => Double.Parse(x, CultureInfo.InvariantCulture)).ToArray();
      return doubles;
    }
  }
}
