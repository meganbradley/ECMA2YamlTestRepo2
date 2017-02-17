    public static SqlDataAdapter CreateSqlDataAdapter(SqlCommand selectCommand,
        SqlConnection connection)
    {
        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        // Create the other commands.
        adapter.InsertCommand = new SqlCommand(
            "INSERT INTO Customers (CustomerID, CompanyName) " +
            "VALUES (@CustomerID, @CompanyName)", connection);

        adapter.UpdateCommand = new SqlCommand(
            "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " +
            "WHERE CustomerID = @oldCustomerID", connection);

        adapter.DeleteCommand = new SqlCommand(
            "DELETE FROM Customers WHERE CustomerID = @CustomerID", connection);

        // Create the parameters.
        adapter.InsertCommand.Parameters.Add("@CustomerID", 
            SqlDbType.Char, 5, "CustomerID");
        adapter.InsertCommand.Parameters.Add("@CompanyName", 
            SqlDbType.VarChar, 40, "CompanyName");

        adapter.UpdateCommand.Parameters.Add("@CustomerID", 
            SqlDbType.Char, 5, "CustomerID");
        adapter.UpdateCommand.Parameters.Add("@CompanyName", 
            SqlDbType.VarChar, 40, "CompanyName");
        adapter.UpdateCommand.Parameters.Add("@oldCustomerID", 
            SqlDbType.Char, 5, "CustomerID").SourceVersion = DataRowVersion.Original;

        adapter.DeleteCommand.Parameters.Add("@CustomerID", 
            SqlDbType.Char, 5, "CustomerID").SourceVersion = DataRowVersion.Original;

        return adapter;
    }