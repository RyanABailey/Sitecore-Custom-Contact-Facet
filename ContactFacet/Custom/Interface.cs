using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactFacet.Custom
{
    public interface ICustomDataFacet : IFacet
    {
        string CrmId { get; set; }
        bool ActiveCustomer { get; set; }
        IElementCollection<IProductPurchaseElement> ProductPurchases { get; }
    }

    public interface IProductPurchaseElement : IElement
    {
        string ProductId { get; set; }
        DateTime PurchaseDate { get; set; }
    }
}