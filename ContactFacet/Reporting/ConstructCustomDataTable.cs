using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ContactFacet.Reporting
{
    public class ConstructCustomDataTable : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            args.ResultTableForView = new DataTable();

            var viewField = new ViewField<string>("CrmId");
            args.ResultTableForView.Columns.Add(viewField.ToColumn());

            var customViewField = new ViewField<bool>("ActiveCustomer");
            args.ResultTableForView.Columns.Add(customViewField.ToColumn());

            var productViewField = new ViewField<DataTable>("ProductPurchases");
            args.ResultTableForView.Columns.Add(productViewField.ToColumn());
        }
    }
}