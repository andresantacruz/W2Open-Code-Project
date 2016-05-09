using System;

namespace W2Open.Common.Utility
{
    /// <summary>
    /// Extension methods to generic types.
    /// </summary>
    public static class W2GenericExt
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0)
                return min;
            else if (val.CompareTo(max) > 0)
                return max;
            else
                return val;
        }
    }
}