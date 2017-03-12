using Sitecore.Analytics.Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactFacet.Custom
{
    [Serializable]
    public class CustomDataFacet : Facet, ICustomDataFacet
    {
        public static readonly string FacetName = "CustomData";
        private const string _PRODUCT_PURCHASES_NAME = "ProductPurchases";
        private const string _CRM_ID_NAME = "CrmId";
        private const string _ACTIVE_CUSTOMER_NAME = "ActiveCustomer";

        public CustomDataFacet()
        {
            EnsureCollection<IProductPurchaseElement>(_PRODUCT_PURCHASES_NAME);
        }

        public IElementCollection<IProductPurchaseElement> ProductPurchases
        {
            get
            {
                return GetCollection<IProductPurchaseElement>(_PRODUCT_PURCHASES_NAME);
            }
        }

        public bool ActiveCustomer
        {
            get
            {
                return GetAttribute<bool>(_ACTIVE_CUSTOMER_NAME);
            }
            set
            {
                SetAttribute(_ACTIVE_CUSTOMER_NAME, value);
            }
        }

        public string CrmId
        {
            get
            {
                return GetAttribute<string>(_CRM_ID_NAME);
            }
            set
            {
                SetAttribute(_CRM_ID_NAME, value);
            }
        }
    }

    [Serializable]
    public class ProductPurchaseElement : Element, IProductPurchaseElement
    {
        private const string _PRODUCT_ID = "ProductId";
        private const string _PURCHASE_DATE = "PurchaseDate";

        public ProductPurchaseElement()
        {
            EnsureAttribute<string>(_PRODUCT_ID);
            EnsureAttribute<DateTime>(_PURCHASE_DATE);
        }

        public string ProductId
        {
            get
            {
                return GetAttribute<string>(_PRODUCT_ID);
            }
            set
            {
                SetAttribute(_PRODUCT_ID, value);
            }
        }

        public DateTime PurchaseDate
        {
            get
            {
                return GetAttribute<DateTime>(_PURCHASE_DATE);
            }
            set
            {
                SetAttribute(_PURCHASE_DATE, value);
            }
        }
    }
}