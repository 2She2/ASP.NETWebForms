using Northwind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_EmpployeesFormView
{
    public partial class EmployeesFormView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var context = new NorthwindEntities())
                {
                    var employees = context.Employees.Select(emp => new
                    {
                        Id = emp.EmployeeID,
                        FullName = emp.FirstName + " " + emp.LastName
                    })
                    .ToList();

                    this.GridViewEmployees.DataSource = employees;
                    this.GridViewEmployees.DataBind();
                }

                this.FormViewEmployees.Visible = false;
                this.ButtonBack.Visible = false;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            this.FormViewEmployees.Visible = false;
            this.GridViewEmployees.Visible = true;
            this.ButtonBack.Visible = false;
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedKey = this.GridViewEmployees.SelectedDataKey;
            int selectedId = Convert.ToInt32(selectedKey.Value);

            using (var context = new NorthwindEntities())
            {
                var employees = context.Employees.Where(x => x.EmployeeID == selectedId).ToList();

                this.FormViewEmployees.DataSource = employees;
                this.FormViewEmployees.DataBind();

                this.FormViewEmployees.Visible = true;
                this.GridViewEmployees.Visible = false;
                this.ButtonBack.Visible = true;
            }
        }

        protected void GridViewEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            using (var context = new NorthwindEntities())
            {
                var employees = context.Employees.Select(emp => new
                {
                    Id = emp.EmployeeID,
                    FullName = emp.FirstName + " " + emp.LastName
                })
                .ToList();

                this.GridViewEmployees.PageIndex = e.NewPageIndex;
                this.GridViewEmployees.DataSource = employees;
                this.GridViewEmployees.DataBind();
            }
        }
    }
}