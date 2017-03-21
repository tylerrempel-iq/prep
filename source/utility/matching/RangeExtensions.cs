using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.utility.matching
{
    public static class RangeExtensions
    {
        public static Criteria<Value> ending_at<Value>(this RangeMatchingExtensionPoint<Value> extension_point, Value value, bool inclusive = false) where Value : IComparable<Value>
        {
            return inclusive ? extension_point.add_criteria(x => x.CompareTo(value) <= 0) : extension_point.add_criteria(x => x.CompareTo(value) < 0);
        }
    }
}
