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

namespace ShowRowColumnCount.Blazor.Server.Controllers;

// For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
public partial class EmployeeListViewController : ObjectViewController<ListView, Employee>
{
    protected override void OnViewControlsCreated()
    {
        base.OnViewControlsCreated();
        if (View.Editor is DxGridListEditor editor)
        {
            editor.GridModel.ColumnResizeMode = GridColumnResizeMode.ColumnsContainer;

            foreach (var columnModel in editor.GridDataColumnModels)
            {
                if (columnModel.FieldName == "Department.Title")
                {
                    columnModel.FilterMenuButtonDisplayMode = GridFilterMenuButtonDisplayMode.Never;
                }
                columnModel.MinWidth = 50;
            }
        }
    }
}