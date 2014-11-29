using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05_Employees_ListView
{
    public partial class ListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new NorthwindEntities())
            {
                var employees = context.Employees.ToList();

                this.ListViewEmployees.DataSource = employees;
                this.ListViewEmployees.DataBind();
            }
            
        }
    }
}