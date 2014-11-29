using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.CookieExchange
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["Pesho"];
            if (cookie != null && cookie.Value == "Logedin")
            {
                this.LabelLogedin.Text = "Loged!";
                this.ButtonLogin.Visible = false;
            }
            else
            {
                this.ButtonLogin.Visible = true;
                this.LabelLogedin.Text = "Please Log in!";
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Pesho", "Logedin");
            DateTime expirationTime = DateTime.Now.AddMinutes(1);
            cookie.Expires = expirationTime;
            Response.Cookies.Add(cookie);

            this.ButtonLogin.Visible = false;
            this.LabelLogedin.Text = "Loged!";
        }

        protected void ButtonGoToPrivateInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PrivateInfo.aspx");
        }
    }
}