using ContactFacet.Custom;
using Sitecore.Cintel;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactFacet.Reporting
{
    public class PopulateCustomData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            ICustomDataFacet fullFacet = (ICustomDataFacet)CustomerIntelligenceManager.ContactService.GetFacet(args.ReportParameters.ContactId, "CustomData");
            var result = args.QueryResult;
            var table = args.ResultTableForView;

            foreach (DataRow row in result.AsEnumerable())
            {
                var targetRow = table.NewRow();

                // CRM ID
                var id = row["CustomData_CrmId"];

                if (id == null || string.IsNullOrEmpty(id.ToString()))
                {
                    continue;
                }
                
                targetRow["CrmId"] = id;

                // Active Customer
                var activeCustomer = row["CustomData_ActiveCustomer"];

                if (activeCustomer == null || string.IsNullOrEmpty(id.ToString()))
                {
                    continue;
                }

                targetRow["ActiveCustomer"] = activeCustomer;

                // Product Purchases
                DataTable productPurchases = new DataTable();
                productPurchases.Columns.Add("Product", typeof(string));
                productPurchases.Columns.Add("Date", typeof(DateTime));

                if (fullFacet.ProductPurchases != null && fullFacet.ProductPurchases.Any())
                {
                    foreach (var purchase in fullFacet.ProductPurchases)
                    {
                        productPurchases.Rows.Add(purchase.ProductId, purchase.PurchaseDate);
                    }
                }

                targetRow["ProductPurchases"] = productPurchases;

                table.Rows.Add(targetRow);
            }

            args.ResultSet.Data.Dataset[args.ReportParameters.ViewName] = table;
        }
    }
}