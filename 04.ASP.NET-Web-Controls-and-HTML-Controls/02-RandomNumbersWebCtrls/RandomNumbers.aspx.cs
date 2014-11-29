using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02_RandomNumbersWebCtrls
{
    public partial class RandomNumbers : System.Web.UI.Page
    {
        protected void GetRandomNumber_Click(object sender, EventArgs e)
        {
            int minNumber = int.Parse(this.TextBoxMinNumber.Text);
            int maxNumber = int.Parse(this.TextBoxMaxNumber.Text);
            Random rand = new Random();
            int currRandomNumber = rand.Next(minNumber, maxNumber + 1);
            this.LabelRandomNumber.Text = currRandomNumber.ToString();
        }
    }
}