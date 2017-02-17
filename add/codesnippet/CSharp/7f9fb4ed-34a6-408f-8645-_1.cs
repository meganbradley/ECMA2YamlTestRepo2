	private void validateUserEntry3()
	{

		// Checks the value of the text.

		if(serverName.Text.Length == 0)
		{

			// Initializes the variables to pass to the MessageBox.Show method.

			string message = "You did not enter a server name. Cancel this operation?";
			string caption = "No Server Name Specified";
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

			result = MessageBox.Show(this, message, caption, buttons,
			MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

			if(result == DialogResult.Yes)
			{

				// Closes the parent form.

				this.Close();

			}

		}

	}
