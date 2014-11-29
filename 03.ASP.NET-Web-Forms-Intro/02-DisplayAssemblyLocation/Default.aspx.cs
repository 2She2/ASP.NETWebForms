using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_DisplayAssemblyLocation
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelHelloCodeBehind.Text = "Hello, ASP.NET";
            this.LabelLocation.Text = Assembly.GetExecutingAssembly().Location.ToString();
        }
    }
}