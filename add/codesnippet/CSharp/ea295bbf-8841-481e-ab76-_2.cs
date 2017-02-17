using System.Web;
using System.Security.Permissions;

namespace Samples.AspNet.CS.Controls
{
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CustomHtmlButtonRenderAttributes : System.Web.UI.HtmlControls.HtmlButton
    {
        protected override void RenderAttributes(System.Web.UI.HtmlTextWriter writer)
        {
            
            // Call the base class's RenderAttributes method.
            base.RenderAttributes(writer);

            // Write out the HtmlButton control's Title tag.
            writer.Write(" Title=\"Text from RenderAttributes.\"");
        }
    }
}