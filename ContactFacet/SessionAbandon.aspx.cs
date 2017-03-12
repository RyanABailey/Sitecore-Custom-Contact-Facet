using ContactFacet.Custom;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactFacet
{
    public partial class SessionAbandon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon(); // Push data through to MongoDB
        }
    }
}