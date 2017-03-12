define(
  ["sitecore",
    "/-/speak/v1/experienceprofile/DataProviderHelper.js",
    "/-/speak/v1/experienceprofile/CintelUtl.js"
  ],
  function (sc, providerHelper, cintelUtil, ExternalDataApiVersion) {
      var cidParam = "cid";
      var intelPath = "/intel";

      var app = sc.Definitions.App.extend({
          initialized: function () {
              $('.sc-progressindicator').first().show().hide();
              var contactId = cintelUtil.getQueryParam(cidParam);
              var tableName = "";
              var baseUrl = "/sitecore/api/ao/v1/contacts/" + contactId + "/intel/custom";

              providerHelper.initProvider(this.CustomDataProvider,
                tableName,
                baseUrl,
                this.ExternalDataTabMessageBar);

              providerHelper.getData(this.CustomDataProvider,
                $.proxy(function (jsonData) {
                    console.log(jsonData);
                    var dataSetProperty = "Data";
                    if (jsonData.data.dataSet != null && jsonData.data.dataSet.custom.length > 0) {
                        // Data present set value content
                        var dataSet = jsonData.data.dataSet.custom[0];
                        this.CustomDataProvider.set(dataSetProperty, jsonData);
                        this.CrmIdValue.set("text", dataSet.CrmId);
                        this.ProductPurchaseDataSource.set('items', dataSet.ProductPurchases);
                    } else {
                        // No data hide the labels
                        this.CrmIdLabel.set("isVisible", false);
                        this.ProductPurchaseLabel.set("isVisible", false);
                        this.ProductPurchaseListControl.set("isVisible", false);
                        this.ExternalDataTabMessageBar.addMessage("notification", this.NoCustomData.get("text"));
                    }
                }, this));
          }
      });
      return app;
  });