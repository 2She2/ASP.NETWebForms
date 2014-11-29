using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.SessionList
{
    public partial class SessionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["allMessages"] = new List<string>();
            }
        }

        protected void ButtonAppendText_Click(object sender, EventArgs e)
        {
            string currentText = Server.HtmlEncode(this.TextBox.Text);
            var allMessages = (Session["allMessages"] as List<string>);

            if (!string.IsNullOrWhiteSpace(currentText))
            {
                allMessages.Add(currentText);
            }

            this.LabelSessionText.Text = string.Empty;

            foreach (var message in allMessages)
            {
                this.LabelSessionText.Text += message + "<br />";
            }
        }
    }
}