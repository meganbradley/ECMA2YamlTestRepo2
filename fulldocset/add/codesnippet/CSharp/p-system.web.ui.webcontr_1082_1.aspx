<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Button CommandName Example</title>
<script runat="server">

      void CommandBtn_Click(Object sender, CommandEventArgs e) 
      {

         switch(e.CommandName)
         {

            case "Sort":

               // Call the method to sort the list.
               Sort_List((String)e.CommandArgument);
               break;

            case "Submit":

               // Display a message for the Submit button being clicked.
               Message.Text = "You clicked the Submit button";

               // Test whether the command argument is an empty string ("").
               if((String)e.CommandArgument == "")
               {
                  // End the message.
                  Message.Text += ".";
               }
               else
               {
                  // Display an error message for the command argument. 
                  Message.Text += ", however the command argument is not recogized.";
               }                
               break;

            default:

               // The command name is not recognized. Display an error message.
               Message.Text = "Command name not recogized.";
               break; 

         }

      }

      void Sort_List(string commandArgument)
      {

         switch(commandArgument)
         {

            case "Ascending":
 
               // Insert code to sort the list in ascending order here.
               Message.Text = "You clicked the Sort Ascending button.";
               break;

            case "Descending":
              
               // Insert code to sort the list in descending order here.
               Message.Text = "You clicked the Sort Descending button.";
               break;

            default:
        
               // The command argument is not recognized. Display an error message.
               Message.Text = "Command argument not recogized.";
               break;

         }

      }

   </script>

</head>
 
<body>

   <form id="form1" runat="server">

      <h3>Button CommandName Example</h3>

      Click on one of the command buttons.

      <br /><br />
 
      <asp:Button id="Button1"
           Text="Sort Ascending"
           CommandName="Sort"
           CommandArgument="Ascending"
           OnCommand="CommandBtn_Click" 
           runat="server"/>

      &nbsp;

      <asp:Button id="Button2"
           Text="Sort Descending"
           CommandName="Sort"
           CommandArgument="Descending"
           OnCommand="CommandBtn_Click" 
           runat="server"/>

      <br /><br />

      <asp:Button id="Button3"
           Text="Submit"
           CommandName="Submit"
           OnCommand="CommandBtn_Click" 
           runat="server"/>

      &nbsp;

      <asp:Button id="Button4"
           Text="Unknown Command Name"
           CommandName="UnknownName"
           CommandArgument="UnknownArgument"
           OnCommand="CommandBtn_Click" 
           runat="server"/>

      &nbsp;

      <asp:Button id="Button5"
           Text="Submit Unknown Command Argument"
           CommandName="Submit"
           CommandArgument="UnknownArgument"
           OnCommand="CommandBtn_Click" 
           runat="server"/>
       
      <br /><br />

      <asp:Label id="Message" runat="server"/>
 
   </form>
 
</body>
</html>
