using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Web.Caching;

public partial class cacheDependencyAdmincs : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    // Put page in default state.
    enabledTables.Visible = true;
    disableTable.Visible = true;
    enabledTablesMsg.Text = "Tables enabled for change notification:";

    tableName.Visible = true;
    enableTable.Visible = true;
    tableEnableMsg.Text = "Enable change notification on table(s):";
    enableTableErrorMsg.Visible = false;
  }

   protected void Page_PreRender(object sender, EventArgs e)
  {
    try
    {
      string[] enabledTablesList =
      SqlCacheDependencyAdmin.GetTablesEnabledForNotifications(
        ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
      if (enabledTablesList.Length > 0)
      {
        enabledTables.DataSource = enabledTablesList;
        enabledTables.DataBind();
      }
      else
      {
        enabledTablesMsg.Text = "No tables are enabled for change notifications.";
        enabledTables.Visible = false;
        disableTable.Visible = false;
      }
    }
    catch (DatabaseNotEnabledForNotificationException ex)
    {
      enabledTables.Visible = false;
      disableTable.Visible = false;
      enabledTablesMsg.Text = "Cache notifications are not enabled in this database.";

      tableName.Visible = false;
      enableTable.Visible = false;
      tableEnableMsg.Text = "Must enable database for notifications before enabling tables";
    }
  }
  protected void enableNotification_Click(object sender, EventArgs e)
  {
    SqlCacheDependencyAdmin.EnableNotifications(
      ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
  }
  protected void disableNotification_Click(object sender, EventArgs e)
  {
    SqlCacheDependencyAdmin.DisableNotifications(
      ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
  }
  protected void disableTable_Click(object sender, EventArgs e)
  {
    foreach (ListItem item in enabledTables.Items)
    {
      if (item.Selected)
      {
        SqlCacheDependencyAdmin.DisableTableForNotifications(
          ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString,
          item.Text);
      }
    }
  }
  protected void enableTable_Click(object sender, EventArgs e)
  {
    try
    {
      if (tableName.Text.Contains(";"))
      {
        string[] tables = tableName.Text.Split(new Char[] { ';' });
        for (int i = 0; i < tables.Length; i++)
          tables[i] = tables[i].Trim();

        SqlCacheDependencyAdmin.EnableTableForNotifications(
          ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString,
          tables);
      }
      else
      {
        SqlCacheDependencyAdmin.EnableTableForNotifications(
          ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString,
          tableName.Text);
      }
    }
    catch (HttpException ex)
    {
      enableTableErrorMsg.Text = "<br />" +
        "An error occured enabling a table.<br />" +
        "The error message was: " +
        ex.Message;
      enableTableErrorMsg.Visible = true;
    }
  }
}