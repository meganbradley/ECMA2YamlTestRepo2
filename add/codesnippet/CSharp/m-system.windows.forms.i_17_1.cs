        private void GetDataPresent3() 
        {
            // Creates a new data object using a string and the Text format.
            DataObject myDataObject = new DataObject(DataFormats.Text, "My String");
 
            // Checks whether the string can be displayed with autoConvert equal to false.
            if(myDataObject.GetDataPresent("System.String", false)) 
                MessageBox.Show(myDataObject.GetData("System.String", false).ToString(), "Message #1");
            else
                MessageBox.Show("Cannot convert data to the specified format with autoConvert set to false.", "Message #1");
 
            // Displays the string with autoConvert equal to true.
            MessageBox.Show("Now that autoConvert is true, you can convert " + 
                myDataObject.GetData("System.String", true).ToString() + " to string format.","Message #2");
        }