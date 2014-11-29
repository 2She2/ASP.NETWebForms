using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05_Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitDigit_Click(object sender, EventArgs e)
        {
            string currButtonText = Server.HtmlEncode((sender as Button).Text);
            this.TextBoxDisplay.Text += currButtonText;
        }

        protected void SubmitOperator_Click(object sender, EventArgs e)
        {
            ViewState["FirstNumber"] = Server.HtmlEncode(this.TextBoxDisplay.Text);
            string currOperator = Server.HtmlEncode((sender as Button).Text);

            ViewState["Operator"] = currOperator;

            if (currOperator != "√")
            {
                this.TextBoxDisplay.Text = "";
            }
        }

        protected void SubmitClear_Click(object sender, EventArgs e)
        {
            this.TextBoxDisplay.Text = "";
        }

        protected void Resolve_Click(object sender, EventArgs e)
        {
            string currOperator = ViewState["Operator"].ToString();
            int firstNumber = int.Parse(ViewState["FirstNumber"].ToString());
            int secondNumber = 0;
            int.TryParse(this.TextBoxDisplay.Text, out secondNumber);
            decimal answer = 0;

            switch (currOperator)
            {
                case "+": answer = firstNumber + secondNumber; break;
                case "-": answer = firstNumber - secondNumber; break;
                case "x": answer = firstNumber * secondNumber; break;
                case "/": answer = firstNumber / secondNumber; break;
                case "√": answer = (decimal)Math.Sqrt(firstNumber); break;
                default: break;
            }

            this.TextBoxDisplay.Text = answer.ToString();

            ViewState["FirstNumber"] = "";
            ViewState["Operator"] = "";
        }

    }
}