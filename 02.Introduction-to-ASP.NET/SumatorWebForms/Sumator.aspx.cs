using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                decimal firstNumber = Decimal.Parse(this.TextFirstNumber.Text);
                decimal secondNumber = Decimal.Parse(this.TextSecondNumber.Text);
                decimal sum = firstNumber + secondNumber;
                this.TextSum.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                this.TextSum.Text = "Please enter valid number";
            }
        }
    }
}