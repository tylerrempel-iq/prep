using System.Collections.Generic;

namespace code.utility.matching
{
    public interface IProvideAccessToFilterBuilders<Item, out ItemProperty>
    {
        Criteria<Item> create_criteria(Criteria<ItemProperty> value_matcher);
        IEnumerable<Item> filter(Criteria<Item> criteria);
    }
}