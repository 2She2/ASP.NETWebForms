
namespace _01_RandomNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class RandomNumbers : System.Web.UI.Page
    {
        protected void GetRandomNumber_Click(object sender, EventArgs e)
        {
            int minNumber = int.Parse(this.TextMinNumber.Value);
            int maxNumber = int.Parse(this.TextMaxNumber.Value);

            Random rand = new Random();
            int currRandomNumber = rand.Next(minNumber, maxNumber + 1);
            this.LabelRandomNumber.InnerText = currRandomNumber.ToString();
        }
    }
}