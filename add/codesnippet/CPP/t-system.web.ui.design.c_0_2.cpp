// Example designer provides a designer verb menu command to launch the
// BuildColor method of the ColorBuilder.
public ref class ColorBuilderDesigner: public System::Web::UI::Design::UserControlDesigner
{
public:
   ColorBuilderDesigner(){}


   property System::ComponentModel::Design::DesignerVerbCollection^ Verbs 
   {

      // Provides a designer verb menu command for invoking the BuildColor
      // method of the ColorBuilder.
      [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
      virtual System::ComponentModel::Design::DesignerVerbCollection^ get() override
      {
         DesignerVerbCollection^ dvc = gcnew DesignerVerbCollection;
         dvc->Add( gcnew DesignerVerb( "Launch Color Builder UI",gcnew EventHandler( this, &ColorBuilderDesigner::launchColorBuilder ) ) );
         return dvc;
      }

   }

private:

   // This method handles the S"Launch Color Builder UI" menu command.
   // Invokes the BuildColor method of the System::Web::UI::Design.ColorBuilder.
   void launchColorBuilder( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      
      // Create a parent control.
      System::Windows::Forms::Control^ c = gcnew System::Windows::Forms::Control;
      c->CreateControl();
      
      // Launch the Color Builder using the specified control
      // parent and an initial HTML format (S"RRGGBB") color String*.
      System::Web::UI::Design::ColorBuilder::BuildColor( this->Component, c, "405599" );
     
   }

};


// Example Web control displays the value of its text property.
// This control is associated with the ColorBuilderDesigner.

[DesignerAttribute(ColorBuilderDesigner::typeid,IDesigner::typeid)]
public ref class ColorBuilderControl: public System::Web::UI::WebControls::WebControl
{
private:
   String^ text;

public:

   property String^ Text 
   {

      [Bindable(true),
      Category("Appearance"),
      DefaultValue("")]
      String^ get()
      {
         return text;
      }

      void set( String^ value )
      {
         text = value;
      }

   }

protected:
   virtual void Render( HtmlTextWriter^ output ) override
   {
      output->Write( Text );
   }

};