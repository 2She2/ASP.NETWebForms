using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.DeleteViewState
{
    public partial class DeleteViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonShowText_Click(object sender, EventArgs e)
        {
            this.LabelShowText.Text = Server.HtmlEncode(this.TextBoxText.Text);
        }
    }
}