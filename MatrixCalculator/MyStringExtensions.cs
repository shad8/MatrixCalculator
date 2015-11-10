using System;
using System.Globalization;
using System.Linq;

namespace MatrixCalculator
{
  public static class MyStringExtensions
  {
    public static double[] ConvertStringToDoubleArray(this string value, char sign)
    {
      if (value.IndexOfAny(new char[] { ',' }) == -1)
        return new double[] { };
      string[] strings = value.Split(sign);
      double[] data = strings.Select(x => Double.Parse(x, CultureInfo.InvariantCulture)).ToArray();
      return data;
    }

    public static int[] ConvertStringToIntArray(this string value, char sign)
    {
      string[] strings = value.Split(sign);
      if (value.IndexOfAny(new char[] { ',' }) == -1)
        return new int[] { };
      int[] data = strings.Select(x => Int32.Parse(x, CultureInfo.InvariantCulture)).ToArray();
      return data;
    }
  }
}
