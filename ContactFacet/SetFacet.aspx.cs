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
    public partial class SetFacet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var identifyUser = IdentifyUser(); // Identify the user

            if (identifyUser)
            {
                var contact = Sitecore.Analytics.Tracker.Current.Contact;
                ICustomDataFacet facet = contact.GetFacet<ICustomDataFacet>(CustomDataFacet.FacetName); // Get the facet

                if (facet != null)
                {
                    facet.ActiveCustomer = true;
                    facet.CrmId = "1234567A";

                    // Product Purchases
                    var productPurchasesField = facet.ProductPurchases.Create();
                    productPurchasesField.ProductId = "PID1";
                    productPurchasesField.PurchaseDate = DateTime.Now;

                    var productPurchasesField2 = facet.ProductPurchases.Create();
                    productPurchasesField2.ProductId = "PID3";
                    productPurchasesField2.PurchaseDate = DateTime.Now;
                }

                // Set email address
                var emailFacet = contact.GetFacet<IContactEmailAddresses>("Emails");

                var personalEmail = emailFacet.Entries.Create("personal");
                personalEmail.SmtpAddress = "test123@email.com";

                emailFacet.Preferred = "personal";
            }
        }

        private bool IdentifyUser()
        {
            var identifiers = Sitecore.Analytics.Tracker.Current.Contact.Identifiers;

            if (identifiers.IdentificationLevel != ContactIdentificationLevel.Known)
            {
                Sitecore.Analytics.Tracker.Current.Session.Identify("test123@email.com"); // Statically bound email :)
                return true;
            }

            return false;
        }
    }
}