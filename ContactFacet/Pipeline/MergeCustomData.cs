using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Pipelines.MergeContacts;
using ContactFacet.Custom;

namespace ContactFacet.Pipeline
{
    public class MergeCustomData : MergeContactProcessor
    {
        public override void Process(MergeContactArgs args)
        {
            var dyingContactFacet = args.DyingContact.GetFacet<ICustomDataFacet>(CustomDataFacet.FacetName);
            var survivingContactFacet = args.SurvivingContact.GetFacet<ICustomDataFacet>(CustomDataFacet.FacetName);
            
            if (dyingContactFacet.IsEmpty)
            {
                return; // No data to merge
            }

            survivingContactFacet.CrmId = dyingContactFacet.CrmId; // Take over the CRM ID
            survivingContactFacet.ActiveCustomer = dyingContactFacet.ActiveCustomer; // Take over active customer flag

            //Copy over products
            if (dyingContactFacet.ProductPurchases != null && dyingContactFacet.ProductPurchases.Any())
            {
                foreach (var productPurcahse in dyingContactFacet.ProductPurchases)
                {
                    var newPurchase = survivingContactFacet.ProductPurchases.Create();
                    newPurchase.PurchaseDate = productPurcahse.PurchaseDate;
                    newPurchase.ProductId = productPurcahse.ProductId;
                }
            }
        }
    }
}