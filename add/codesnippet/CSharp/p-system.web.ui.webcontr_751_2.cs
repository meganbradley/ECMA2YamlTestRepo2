  protected void Button1_Click(object sender, EventArgs e)
  {

    Label2.Text =
      @"<h3>Calendar GenericWebPart Properties</h3>" +
      "<em>Title: </em>" + calendarPart.Title +
      "<br />" +
      "<em>CatalogIconImageUrl:  </em>" + calendarPart.CatalogIconImageUrl +
      "<br />" +
      "<em>TitleUrl: </em>" + calendarPart.TitleUrl +
      "<br />" +
      "<em>Decription: </em>" + calendarPart.Description +
      "<br />" +
      "<em>TitleIconImageUrl: </em>" + calendarPart.TitleIconImageUrl +
      "<br />" +
      "<em>ChildControl ID: </em>" + calendarPart.ChildControl.ID +
      "<br />" +
      "<em>ChildControl Type: </em>" + calendarPart.ChildControl.GetType().Name +
      "<br />" +
      "<em>GenericWebPart ID: </em>" + calendarPart.ID +
      "<br />" +
      "<em>GenericWebPart Type: </em>" + calendarPart.GetType().Name +
      "<br />" +
      "<em>GenericWebPart Parent ID: </em>" + calendarPart.Parent.ID;

    Label3.Text =
      @"<h3>BulletedList GenericWebPart Properties</h3>" +
      "<em>Title: </em>" + listPart.Title +
      "<br />" +
      "<em>CatalogIconImageUrl:  </em>" + listPart.CatalogIconImageUrl +
      "<br />" +
      "<em>TitleUrl: </em>" + listPart.TitleUrl +
      "<br />" +
      "<em>Decription: </em>" + listPart.Description +
      "<br />" +
      "<em>TitleIconImageUrl: </em>" + listPart.TitleIconImageUrl +
      "<br />" +
      "<em>ChildControl ID: </em>" + listPart.ChildControl.ID +
      "<br />" +
      "<em>ChildControl Type: </em>" + listPart.ChildControl.GetType().Name +
      "<br />" +
      "<em>GenericWebPart ID: </em>" + listPart.ID +
      "<br />" +
      "<em>GenericWebPart Type: </em>" + listPart.GetType().Name +
      "<br />" +
      "<em>GenericWebPart Parent ID: </em>" + listPart.Parent.ID;
  }