namespace _06.VisitsCounterSqlServer
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web;

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new VisitsCountEntities())
            {
                var visitsCounter = context.Visits.FirstOrDefault(v => v.Id == "COUNTS");
                if (visitsCounter == null)
                {
                    Response.Write("No data found in DB.");
                    return;
                }

                visitsCounter.Visits++;
                context.SaveChanges();

                Response.Clear();

                this.GenerateImage(
                    Response,
                    visitsCounter.Visits.ToString(),
                    200,
                    200,
                    Color.MediumSeaGreen,
                    FontFamily.GenericSansSerif,
                    18,
                    Brushes.Yellow,
                    80,
                    80,
                    "image/jpeg",
                    ImageFormat.Jpeg);
            }
        }

        private void GenerateImage(
        HttpResponse response,
        string textToInsert,
        int width,
        int height,
        Color backgroundColor,
        FontFamily fontFamily,
        float emSize,
        Brush brush,
        float x,
        float y,
        string contentType,
        ImageFormat imageFormat)
        {
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(backgroundColor);
                    graphics.DrawString(textToInsert, new Font(fontFamily, emSize), brush, x, y);
                    response.ContentType = contentType;
                    bitmap.Save(response.OutputStream, imageFormat);
                }
            }
        }
    }
}