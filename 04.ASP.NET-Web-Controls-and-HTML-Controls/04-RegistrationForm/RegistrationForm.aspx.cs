using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _04_RegistrationForm
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        // Simulate database info!
        private string[] sofiiskiSpecialties = 
        {
            "",
            "Sofiiski specialty 1",
            "Sofiiski specialty 2",
            "Sofiiski specialty 3"
        };

        private string[] tehnicheskiSpecialties =
        {
            "",
            "Tehnicheski specialty 1",
            "Tehnicheski specialty 2",
            "Tehnicheski specialty 3"
        };

        private string[] unssSpecialties =
        {
            "",
            "UNSS specialty 1",
            "UNSS specialty 2",
            "UNSS specialty 3"
        };

        private string[] sofiiskiCourses =
        {
            "Sofiiski course 1",
            "Sofiiski course 2",
            "Sofiiski course 3"
        };

        private string[] tehnicheskiCourses =
        {
            "Tehnicheski course 1",
            "Tehnicheski course 2",
            "Tehnicheski course 3"
        };

        private string[] unssCourses =
        {
            "UNSS course 1",
            "UNSS course 2",
            "UNSS course 3"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DisplayUserInfo_Click(object sender, EventArgs e)
        {
            string firstName = Server.HtmlEncode(this.TextBoxFirstName.Text);
            string lastName = Server.HtmlEncode(this.TextBoxLastName.Text);
            string facultyNumber = Server.HtmlEncode(this.TextBoxFacultyNumber.Text);
            string university = Server.HtmlEncode(this.DropDownListUniversity.SelectedItem.Text);
            string specialty = Server.HtmlEncode(this.DropDownListSpecialty.SelectedItem.Text);
            List<string> courses = new List<string>();
            foreach (ListItem item in this.ListBoxCourses.Items)
            {
                if (item.Selected)
                {
                    courses.Add(item.Text);
                }
            }

            // First way
            var h1UserInfo = new HtmlGenericControl("h1");
            var h2FirstName = new HtmlGenericControl("h2");
            var h2LastName = new HtmlGenericControl("h2");
            var h2FacultyNumber = new HtmlGenericControl("h2");
            var h2University = new HtmlGenericControl("h2");
            var h2Specialty = new HtmlGenericControl("h2");

            h1UserInfo.InnerHtml = "User Info:";
            h2FirstName.InnerHtml = firstName;
            h2LastName.InnerHtml = lastName;
            h2FacultyNumber.InnerHtml = facultyNumber;
            h2University.InnerHtml = university;
            h2Specialty.InnerHtml = specialty;

            this.PanelUserInfo.Controls.Add(h1UserInfo);
            this.PanelUserInfo.Controls.Add(h2FirstName);
            this.PanelUserInfo.Controls.Add(h2LastName);
            this.PanelUserInfo.Controls.Add(h2FacultyNumber);
            this.PanelUserInfo.Controls.Add(h2University);
            this.PanelUserInfo.Controls.Add(h2Specialty);

            var userCourses = new HtmlGenericControl("p");
            foreach (var course in courses)
            {
                userCourses.InnerHtml += course + "<br/>";
            }

            this.PanelUserInfo.Controls.Add(userCourses);
        }

        protected void DropDownListUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListSpecialty.Items.Clear();
            this.DropDownListSpecialty.SelectedValue = null;

            this.ListBoxCourses.Items.Clear();
            this.ListBoxCourses.SelectedValue = null;

            string university = this.DropDownListUniversity.SelectedValue;

            string[] specialties;

            switch (university)
            {
                case "Sofiiski": specialties = this.sofiiskiSpecialties; break;
                case "Tehnicheski": specialties = this.tehnicheskiSpecialties; break;
                case "UNSS": specialties = this.unssSpecialties; break;
                default: Response.Write("<h1>Please enter university</h1>"); return;
            }

            for (int i = 0; i < specialties.Length; i++)
            {
                var currSpecialty = new ListItem(specialties[i], i.ToString());
                this.DropDownListSpecialty.Items.Add(currSpecialty);
            }
        }

        protected void DropDownListSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListBoxCourses.Items.Clear();
            this.ListBoxCourses.SelectedValue = null;

            string course = this.DropDownListSpecialty.SelectedValue;

            string[] courses;

            switch (course)
            {
                case "1": courses = this.sofiiskiCourses; break;
                case "2": courses = this.tehnicheskiCourses; break;
                case "3": courses = this.unssCourses; break;
                default: Response.Write("<h1>Please enter specialty</h1>"); return;
            }

            for (int i = 0; i < courses.Length; i++)
            {
                var currCourse = new ListItem(courses[i], i.ToString());
                this.ListBoxCourses.Items.Add(currCourse);
            }
        }
    }
}