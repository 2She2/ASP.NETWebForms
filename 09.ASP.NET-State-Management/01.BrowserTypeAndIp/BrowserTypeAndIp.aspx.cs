namespace _01.BrowserTypeAndIp
{
    using System;

    public partial class BrowserTypeAndIp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralBrowserType.Text = Request.Browser.Type;


            // First way
            // this.LiteralIp.Text = Request.ServerVariables["REMOTE_ADDR"];

            // Second way
            this.LiteralIp.Text = Request.UserHostAddress;
        }
    }
}