using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_HtmlEscaping
{
    public partial class HtmlEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowEscapedText_Click(object sender, EventArgs e)
        {
            string inputText = this.TextBoxInputText.Text;
            this.TextBoxEscapedText.Text = Server.HtmlEncode(inputText);
            this.LabelEscapedText.Text = Server.HtmlEncode(inputText);
        }
    }
}