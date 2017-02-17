<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB" Assembly="Samples.AspNet.VB" %>
<%@ Page language="vb" %>
<%@ Import namespace="Samples.AspNet.VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

' Add parameters and initialize the user interface
' only if an employee is selected.
Private Sub Page_Load(sender As Object, e As EventArgs)

  ' Be sure the text boxes are initialized with
  ' data from the currently selected employee.
  Dim selectedEmployee As NorthwindEmployee
  selectedEmployee = EmployeeLogic.GetEmployee(DropDownList1.SelectedValue)

  If Not selectedEmployee Is Nothing Then
    AddressBox.Text    = selectedEmployee.Address
    CityBox.Text       = selectedEmployee.City
    PostalCodeBox.Text = selectedEmployee.PostalCode

    Button1.Enabled = True
  Else
    Button1.Enabled = False
  End If
End Sub ' Page_Load

' Press the button to update.
Private Sub Btn_UpdateEmployee (sender As Object, e As CommandEventArgs )
  ObjectDataSource2.Update()
End Sub ' Btn_UpdateEmployee

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>ObjectDataSource - VB Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">

        <!-- The DropDownList is bound to the first ObjectDataSource. -->
        <asp:objectdatasource
          id="ObjectDataSource1"
          runat="server"
          selectmethod="GetAllEmployees"
          typename="Samples.AspNet.VB.EmployeeLogic" />

        <p><asp:dropdownlist
          id="DropDownList1"
          runat="server"
          datasourceid="ObjectDataSource1"
          datatextfield="FullName"
          datavaluefield="EmpID"
          autopostback="True" /></p>

        <!-- The second ObjectDataSource performs the Update. This
             preserves the state of the DropDownList, which otherwise
             would rebind when the DataSourceChanged event is
             raised as a result of an Update operation. -->

        <!-- Security Note: The ObjectDataSource uses a FormParameter,
             Security Note: which does not perform validation of input from the client.
             Security Note: To validate the value of the FormParameter,
             Security Note: handle the Updating event. -->

        <asp:objectdatasource
          id="ObjectDataSource2"
          runat="server"
          updatemethod="UpdateEmployeeWrapper"
          typename="Samples.AspNet.VB.EmployeeLogic">
          <updateparameters>
            <asp:controlparameter name="anID" controlid="DropDownList1" propertyname="SelectedValue" />
            <asp:formparameter name="anAddress" formfield="AddressBox" />
            <asp:formparameter name="aCity" formfield="CityBox" />
            <asp:formparameter name="aPostalCode" formfield="PostalCodeBox" />
          </updateparameters>
        </asp:objectdatasource>

        <p><asp:textbox
          id="AddressBox"
          runat="server" /></p>

        <p><asp:textbox
          id="CityBox"
          runat="server" /></p>

        <p><asp:textbox
          id="PostalCodeBox"
          runat="server" /></p>

        <asp:button
          id="Button1"
          runat="server"
          text="Update Employee"
          oncommand="Btn_UpdateEmployee" />

    </form>
  </body>
</html>