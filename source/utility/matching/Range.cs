using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace code.utility.matching
{
    public class Range
    {
        public static RangeMatchingExtensionPoint<Value> starting_at<Value>(Value value, bool inclusive = false)
            where Value : IComparable<Value>
        {
            return inclusive ? new RangeMatchingExtensionPoint<Value>(x => x.CompareTo(value) >= 0) : new RangeMatchingExtensionPoint<Value>(x => x.CompareTo(value) > 0);
        }

        public static RangeMatchingExtensionPoint<Value> ending_at<Value>(Value value, bool inclusive = false) where Value : IComparable<Value>
        {
            return inclusive ? new RangeMatchingExtensionPoint<Value>(x => x.CompareTo(value) <= 0) : new RangeMatchingExtensionPoint<Value>(x => x.CompareTo(value) < 0);
        }
    }
}
