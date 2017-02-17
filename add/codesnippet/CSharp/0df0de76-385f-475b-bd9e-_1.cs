        public void FillClosedCurvePointFFillModeTension(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create array of points for curve.
            PointF point1 = new PointF(100.0F, 100.0F);
            PointF point2 = new PointF(200.0F,  50.0F);
            PointF point3 = new PointF(250.0F, 200.0F);
            PointF point4 = new PointF(50.0F, 150.0F);
            PointF[] points = {point1, point2, point3, point4};
                     
            // Set fill mode.
            FillMode newFillMode = FillMode.Winding;
                     
            // Set tension.
            float tension = 1.0F;
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points, newFillMode, tension);
        }