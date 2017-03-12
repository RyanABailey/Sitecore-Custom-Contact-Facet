using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using Sitecore.Cintel.Reporting.ReportingServerDatasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactFacet.Reporting
{
    public class GetCustomData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            var queryExpression = this.CreateQuery().Build();
            var table = base.GetTableFromContactQueryExpression(queryExpression, args.ReportParameters.ContactId, null);
            args.QueryResult = table;
        }
        protected virtual QueryBuilder CreateQuery()
        {
            var builder = new QueryBuilder
            {
                collectionName = "Contacts"
            };
            builder.Fields.Add("_id");
            builder.Fields.Add("CustomData_CrmId");
            builder.Fields.Add("CustomData_ActiveCustomer");
            builder.QueryParms.Add("_id", "@contactid");
            return builder;
        }
    }
}