using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_HelloPage
{
    public partial class HelloPage : System.Web.UI.Page
    {
        protected void ButtonShowName_Click(object sender, EventArgs e)
        {
            string name = this.TextBoxName.Text;
            Label label = new Label();
            label.Text = name;
            this.PaneName.Controls.Add(label);
        }
    }
}