        private void DrawIconRectangle(PaintEventArgs e)
        {        
            // Create icon.
            Icon newIcon = new Icon("SampIcon.ico");
                     
            // Create rectangle for icon.
            Rectangle rect = new Rectangle(100, 100, 200, 200);
                     
            // Draw icon to screen.
            e.Graphics.DrawIcon(newIcon, rect);
        }