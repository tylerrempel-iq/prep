using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.utility.matching
{
    public class FallsIn
    {
        public static Criteria<Value> range<Value>(Criteria<Value> rangeSpecification)
        {
            return rangeSpecification;
        } 
    }

    public static class FallsInMatchingExtensions
    {
        public static Criteria<Item> falls_in<Item, Property>(this IProvideAccessToMatchBuilders<Item, Property> extension_point, Criteria<Property> rangeSpecification)
        {
            return extension_point.create(FallsIn.range(rangeSpecification));
        }

        public static Criteria<Item> falls_in<Item, Property>(this IProvideAccessToMatchBuilders<Item, Property> extension_point, RangeMatchingExtensionPoint<Property> rangeSpecification) where Property : IComparable<Property>
        {
            return extension_point.create(FallsIn.range(rangeSpecification.add_criteria(x => true)));
        }
    }
}
