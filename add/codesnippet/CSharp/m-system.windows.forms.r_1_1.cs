 private void radioButton1_CheckedChanged(Object sender, 
                                          EventArgs e)
 {
    /* Change the check box position to 
    be the opposite its current position.*/
    if (radioButton1.CheckAlign == ContentAlignment.MiddleLeft)
    {
       radioButton1.CheckAlign = ContentAlignment.MiddleRight;
    }
    else
    {
       radioButton1.CheckAlign = ContentAlignment.MiddleLeft;
    }
 }
 