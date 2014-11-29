using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind;

namespace _04_EmployeesRepeater
{
    public partial class EmpRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new NorthwindEntities())
            {
                var employees = context.Employees.ToList();

                this.RepeaterEmployees.DataSource = employees;
                this.RepeaterEmployees.DataBind();
            }
        }
    }
}