using System;

namespace code.utility.matching
{
    public class RangeMatchingExtensionPoint<Property> where Property : IComparable<Property>
    {
        private Criteria<Property> initial_criteria;

        public RangeMatchingExtensionPoint(Criteria<Property> initial_criteria)
        {
            this.initial_criteria = initial_criteria;
        } 

        public Criteria<Property> add_criteria(Criteria<Property> criteria)
        {
            return initial_criteria.and(criteria);
        }
    }
}