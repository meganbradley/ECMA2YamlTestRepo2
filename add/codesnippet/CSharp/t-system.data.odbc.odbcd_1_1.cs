    public DataSet GetDataSetFromAdapter(
        DataSet dataSet, string connectionString, string queryString)
    {
        using (OdbcConnection connection = 
                   new OdbcConnection(connectionString))
        {
            OdbcDataAdapter adapter = 
                new OdbcDataAdapter(queryString, connection);

            // Open the connection and fill the DataSet.
            try
            {
                connection.Open();
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
        }
        return dataSet;
    }