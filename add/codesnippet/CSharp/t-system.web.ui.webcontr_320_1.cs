public partial class LoginCancelEventArgscs_aspx : System.Web.UI.Page
{

    bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        return System.Text.RegularExpressions.Regex.IsMatch(strIn, 
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    }
    
    protected void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
    {
        if (!IsValidEmail(Login1.UserName))
        {
            Login1.InstructionText = "You must enter a valid e-mail address.";
            e.Cancel = true;
        }
        else
        {
            Login1.InstructionText = String.Empty;
        }
    }
}