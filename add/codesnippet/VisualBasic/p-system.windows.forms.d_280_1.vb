    Private Sub GetPropertyDescriptor()
        Dim pd As PropertyDescriptor
        pd = dataGrid1.TableStyles(0).GridColumnStyles(0).PropertyDescriptor
        Console.WriteLine(pd.ToString())
    End Sub 'GetPropertyDescriptor
    
    
    Private Sub CreateNewDataGridColumnStyle()
        Dim myGridColumnCol As GridColumnStylesCollection
        myGridColumnCol = dataGrid1.TableStyles(0).GridColumnStyles
        ' Get the CurrencyManager for the table you want to add a column to.
        Dim myCurrencyManager As CurrencyManager = CType(Me.BindingContext(ds.Tables("Suppliers")), CurrencyManager)
        ' Get the PropertyDescriptor for the DataColumn of the new column.
        Dim pd As PropertyDescriptor = myCurrencyManager.GetItemProperties()("City")
        Dim myColumn As New DataGridTextBoxColumn(pd)
        myGridColumnCol.Add(myColumn)
    End Sub 'CreateNewDataGridColumnStyle