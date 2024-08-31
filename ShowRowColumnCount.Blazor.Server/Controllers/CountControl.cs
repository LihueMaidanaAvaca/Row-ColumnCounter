using DevExpress.Blazor;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using ShowRowColumnCount.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowRowColumnCount.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CountControl : ObjectViewController<ListView, Employee>
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CountControl()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            if (View.Editor is DxGridListEditor gridListEditor)
            {

                gridListEditor.GridModel.FooterDisplayMode = GridFooterDisplayMode.Always;


                var column = gridListEditor.GridDataColumnModels.First();
                var objectSpace = View.ObjectSpace;

                column.FooterTemplate = (GridColumnFooterTemplateContext context) => builder =>
                {
                    var rowCount = gridListEditor.GridInstance.GetVisibleRowCount();
                    var columnCount = gridListEditor.GridDataColumnModels.Count();
                    builder.AddMarkupContent(0, $"{rowCount} rows and {columnCount} columns");
                };
            }
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
