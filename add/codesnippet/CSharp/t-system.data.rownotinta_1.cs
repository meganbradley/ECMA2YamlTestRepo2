    private void DemonstrateRowNotInTableException()
    {
        // Create a DataTable with one column and ten rows.      
        DataTable table = new DataTable("NewTable");
        DataColumn column = new DataColumn("NewColumn");
        table.Columns.Add(column);

        DataRow newRow;
        for(int i = 0;i <10;i++)
        {
            newRow = table.NewRow();
            newRow["NewColumn"] = i;
            table.Rows.Add(newRow);
        }
        try
        {
            // Remove a row and invoke AcceptChanges.
            DataRow removedRow = table.Rows[9];
            removedRow.Delete();
            removedRow.AcceptChanges();
 
        }
        catch(System.Data.RowNotInTableException rowException)
        {
            Console.WriteLine("Row not in table");
        }
    }