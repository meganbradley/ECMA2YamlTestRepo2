<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
    "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        // Display the day header
        Calendar1.ShowDayHeader = true;
        
        // This allows the user to select a week or a month at a time.
        Calendar1.SelectionMode =
           CalendarSelectionMode.DayWeekMonth;
        // Set the BorderStyle and BorderColor properties.
        Calendar1.WebCalendar.DayStyle.BorderStyle =
           BorderStyle.Solid;
        Calendar1.WebCalendar.DayStyle.BorderColor = Color.Cyan;

        Calendar1.CalendarEntryText = "Your birthdate";
        
        Calendar1.VisibleDate = DateTime.Parse("7/1/" + 
            DateTime.Now.Year.ToString());
    }

    protected void ShowChanges(Object sender, EventArgs e)
    {
        TextView1.Text = "The date you selected is " +
           Calendar1.SelectedDate.ToShortDateString();
        
        // Distinguish the selected block using colors.
        Calendar1.WebCalendar.SelectedDayStyle.BackColor =
           Color.LightGreen;
        Calendar1.WebCalendar.SelectedDayStyle.BorderColor =
           Color.Gray;
        Calendar1.WebCalendar.DayStyle.BorderColor = Color.Blue;
    }

    protected void Command1_Click(object sender, EventArgs e)
    {
        int currentDay = Calendar1.VisibleDate.Day;
        int currentMonth = Calendar1.VisibleDate.Month;
        int currentYear = Calendar1.VisibleDate.Year;
        Calendar1.SelectedDates.Clear();

        // Add all Wednesdays to the collection.
        for (int i = 1; i <= System.DateTime.DaysInMonth(currentYear,
               currentMonth); i++)
        {
            DateTime targetDate = new DateTime(currentYear, currentMonth, i);
            if (targetDate.DayOfWeek == DayOfWeek.Wednesday)
                Calendar1.SelectedDates.Add(targetDate);
        }
        TextView1.Text = "Selection Count ="
           + Calendar1.SelectedDates.Count.ToString();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Calendar id="Calendar1" runat="server"
            OnSelectionChanged="ShowChanges" />
        <mobile:TextView runat="server" id="TextView1" />
        <mobile:Command ID="Command1" OnClick="Command1_Click" 
            Runat="server">Select Wednesdays</mobile:Command>
    </mobile:form>
</body>
</html>