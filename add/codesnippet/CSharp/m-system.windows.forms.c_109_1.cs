    private void dataGrid1_KeyUp
    (object sender, System.Windows.Forms.KeyEventArgs e) {
        if(e.KeyCode == Keys.Enter) {
            // Enter key pressed.
            CurrencyManager gridCurrencyManager = 
            (CurrencyManager)this.BindingContext
            [dataGrid1.DataSource, dataGrid1.DataMember];
            gridCurrencyManager.EndCurrentEdit();
            MessageBox.Show("End Edit");
        }
    }