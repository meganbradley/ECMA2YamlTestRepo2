private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      fontDialog1->ShowColor = true;

      fontDialog1->Font = textBox1->Font;
      fontDialog1->Color = textBox1->ForeColor;

      if ( fontDialog1->ShowDialog() != ::DialogResult::Cancel )
      {
         textBox1->Font = fontDialog1->Font;
         textBox1->ForeColor = fontDialog1->Color;
      }
   }