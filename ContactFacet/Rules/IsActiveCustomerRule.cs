using ContactFacet.Custom;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactFacet.Rules
{
    public class IsActiveCustomerRule<T> : TrueCondition<T> where T : RuleContext
    {
        protected override bool Execute(T ruleContext)
        {
            try
            {
                var contact = Sitecore.Analytics.Tracker.Current.Contact;
                ICustomDataFacet facet = contact.GetFacet<ICustomDataFacet>(CustomDataFacet.FacetName); // Get the facet

                return facet.ActiveCustomer;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}