namespace ValidateRegisterForm
{
    using System;
    using System.Web.UI.WebControls;

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }

        public void checkCheckBox(object o, ServerValidateEventArgs e)
        {
            e.IsValid = chkIAccept.Checked;
        }
    }
}