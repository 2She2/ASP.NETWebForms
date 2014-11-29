using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind;

namespace _02_Employees
{
    public partial class EmpDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["PrevPage"] = Request.UrlReferrer;
            }


            string id = Request.Params["Id"];

            if (string.IsNullOrWhiteSpace(id))
            {
                Response.Redirect("Employees.aspx");
            }

            int idInt = int.Parse(id);

            using (var context = new NorthwindEntities())
            {
                var currEmployee = context.Employees.Where(x => x.EmployeeID == idInt).ToList();
                this.DetailsViewEmployee.DataSource = currEmployee;
                this.DetailsViewEmployee.DataBind();
            }

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (ViewState["PrevPage"] != null)
            {
                Response.Redirect(ViewState["PrevPage"].ToString());
            }
        }
    }
}