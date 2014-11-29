using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using World;

namespace _01_WorldManagement
{
    public partial class World : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonUpdateContinent_Click(object sender, EventArgs e)
        {
            string newName = Server.HtmlEncode(this.TextBoxUpdateContinent.Text);

            if (string.IsNullOrWhiteSpace(newName))
            {
                Response.Write("Please enter name to update continent!");
                return;
            }

            if (newName.Length > 20)
            {
                Response.Write("Continent name must be less than 20 symbols!");
            }

            var selectedContinentId = this.ListBoxContinents.SelectedItem.Value;
            WorldEntities db = new WorldEntities();

            var continent = db.Continents.FirstOrDefault(c => c.ContinentId.ToString() == selectedContinentId);
            if (continent == null)
            {
                Response.Write("Selected continent was not found!");
                return;
            }

            continent.ContinentName = newName;
            db.Entry<Continent>(continent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonDeleteContinent_Click(object sender, EventArgs e)
        {
            string newName = Server.HtmlEncode(this.TextBoxUpdateContinent.Text);

            if (string.IsNullOrWhiteSpace(newName))
            {
                Response.Write("Please enter name to delete continent!");
                return;
            }

            var selectedContinentId = this.ListBoxContinents.SelectedItem.Value;
            WorldEntities db = new WorldEntities();

            var continent = db.Continents.FirstOrDefault(c => c.ContinentId.ToString() == selectedContinentId);
            if (continent == null)
            {
                Response.Write("Selected continent was not found!");
                return;
            }

            db.Entry<Continent>(continent).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedContinent = Server.HtmlEncode(this.ListBoxContinents.SelectedItem.Text);
            this.TextBoxUpdateContinent.Text = selectedContinent;
        }

        protected void ButtonAddContinent_Click(object sender, EventArgs e)
        {
            string newName = this.TextBoxUpdateContinent.Text;

            if (string.IsNullOrWhiteSpace(newName))
            {
                Response.Write("Please enter name to Create continent!");
                return;
            }

            if (newName.Length > 20)
            {
                Response.Write("Continent name must be less than 20 symbols!");
            }

            WorldEntities db = new WorldEntities();

            Continent newContinent = new Continent()
            {
                ContinentName = newName
            };

            db.Continents.Add(newContinent);
            db.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }

        protected void ButtonAddCountry_Click(object sender, EventArgs e)
        {
            string newCountryID = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxAddCountryId");
            if (!IsValidCountryId(newCountryID))
            {
                return;
            }

            string newCountryName = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxAddCountry");
            if (!IsValidCountryName(newCountryName))
            {
                return;
            }

            string newCountryLatitude = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxAddLatitude");
            float latitude;
            if (!float.TryParse(newCountryLatitude, out latitude))
            {
                Response.Write("Enter correct latitude!");
                return;
            }

            string newCountryLongitude = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxAddLongitude");
            float longitude;
            if (!float.TryParse(newCountryLongitude, out longitude))
            {
                Response.Write("Enter correct longitude!");
                return;
            }

            string newCountrySurfaceArea = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxAddSurfaceArea");
            int surfaceArea;
            if (!int.TryParse(newCountrySurfaceArea, out surfaceArea))
            {
                Response.Write("Enter correct Surface Area (int number)!");
                return;
            }

            string newCountryPopulation = this.GetFooterRowTextBoxText(this.GridViewCountries, "TextBoxAddPopulation");
            int population;
            if (!int.TryParse(newCountryPopulation, out population))
            {
                Response.Write("Enter correct population (int number)!");
                return;
            }

            ListBox listBoxLanguages = this.GridViewCountries.FooterRow.FindControl("ListBoxAddLanguages") as ListBox;
            int[] listBoxLanguagesIndices = listBoxLanguages.GetSelectedIndices();

            if (listBoxLanguagesIndices.Length < 1)
            {
                Response.Write("Correct Country is required!");
                return;
            }

            Country newCountry = new Country()
            {
                CountryId = newCountryID,
                CountryName = newCountryName,
                Latitude = latitude,
                Longitude = longitude,
                SurfaceArea = surfaceArea,
                Population = population
            };

            WorldEntities db = new WorldEntities();
            var allLanguages = listBoxLanguages.Items;
            string currSelectedLanguageId = string.Empty;
            Language currLanguage;
            foreach (int languageIndex in listBoxLanguagesIndices)
            {
                currSelectedLanguageId = allLanguages[languageIndex].Value;
                currLanguage = db.Languages.FirstOrDefault(lang => lang.LanguageId.ToString() == currSelectedLanguageId);

                if (currLanguage == null)
                {
                    Response.Write("Invalid Country entered!");
                    return;
                }

                newCountry.Languages.Add(currLanguage);
            }

            var selectedContinentId = this.ListBoxContinents.SelectedItem.Value;

            var continent = db.Continents.FirstOrDefault(c => c.ContinentId.ToString() == selectedContinentId);
            if (continent == null)
            {
                Response.Write("Selected continent was not found!");
                return;
            }

            newCountry.Continent = continent;

            FileUpload fileUploadControl = this.GridViewCountries.FooterRow.FindControl("FileUploadFlagChange") as FileUpload;
            byte[] fileData = this.GetUploadedFile(fileUploadControl.PostedFile);
            newCountry.FlagImage = fileData;

            db.Countries.Add(newCountry);
            db.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }

        protected void GridViewCountries_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            WorldEntities db = null;
            this.LabelCountryErrors.Text = string.Empty;

            try
            {
                string countryName = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxCountryNameEdit") as TextBox).Text;
                this.ValidateName(countryName);

                float latitude;
                string latitudeString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxLatitudeEdit") as TextBox).Text;
                this.ValidateCoordinate(latitudeString, out latitude);

                float longitude;
                string longitudeString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxLongitudeEdit") as TextBox).Text;
                this.ValidateCoordinate(longitudeString, out longitude);

                int surfaceArea;
                string surfaceAreaString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxSurfaceAreaEdit") as TextBox).Text;
                this.ValidateSurfaceArea(surfaceAreaString, out surfaceArea);

                int population;
                string populationString = (this.GridViewCountries.Rows[e.RowIndex].FindControl("TextBoxPopulationEdit") as TextBox).Text;
                this.ValidatePopulation(populationString, out population);

                db = new WorldEntities();

                string selectedCountryId = this.GridViewCountries.DataKeys[e.RowIndex].Value.ToString();

                var country = db.Countries.FirstOrDefault(c => c.CountryId == selectedCountryId);
                if (country != null)
                {
                    var postedFile = (this.GridViewCountries.Rows[e.RowIndex].FindControl("FileUploadFlagChange") as FileUpload).PostedFile;

                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        byte[] data = this.GetUploadedFile(postedFile);
                        country.FlagImage = data;
                        db.Entry<Country>(country).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    country.Languages.Clear();

                    string newLanguageNames = this.GetTextBoxText(this.GridViewCountries, e.RowIndex, "TextBoxLanguages");
                    string[] languageNames = newLanguageNames.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string languageName in languageNames)
                    {
                        var language = db.Languages.FirstOrDefault(lang => string.Compare(lang.LanguageName, languageName, true) == 0);
                        if (language == null)
                        {
                            language = new Language
                            {
                                LanguageName = languageName
                            };

                            db.Languages.Add(language);
                            db.SaveChanges();
                        }

                        country.Languages.Add(language);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                this.LabelCountryErrors.Text = ex.Message;
                e.Cancel = true;
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }

        protected void GridViewCountries_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void GridViewCountries_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string confirmValue = Request.Form["confirm-value"];
            if (confirmValue == "No")
            {
                e.Cancel = true;
            }
        }

        protected void GridViewCountries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
            {
                //In this sample, there are  3 buttons and the second one is Delete button, that's why we use the index 2
                //indexing goes as 0 is button #1, 1 Literal (Space between buttons), 2 button #2, 3 Literal (Space) etc.
                ((LinkButton)e.Row.Cells[0].Controls[2]).OnClientClick = "Confirm()";
            }
        }

        protected void ListViewCities_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            this.LabelCityErrors.Text = string.Empty;

            try
            {
                string cityName = (e.Item.FindControl("CityNameTextBox") as TextBox).Text;
                this.ValidateName(cityName);

                float latitude;
                string latitudeAsString = (e.Item.FindControl("LatitudeTextBox") as TextBox).Text;
                this.ValidateCoordinate(latitudeAsString, out latitude);

                float longitude;
                string longitudeAsString = (e.Item.FindControl("LongitudeTextBox") as TextBox).Text;
                this.ValidateCoordinate(longitudeAsString, out longitude);

                int population;
                string populationAsString = (e.Item.FindControl("PopulationTextBox") as TextBox).Text;
                this.ValidatePopulation(populationAsString, out population);

                var countryId = this.GridViewCountries.SelectedDataKey.Value.ToString();

                this.EntityDataSourceTowns.InsertParameters.Add("CountryId", TypeCode.String, countryId);

                this.ListViewCities.DataBind();
            }
            catch (Exception ex)
            {
                this.LabelCityErrors.Text = ex.Message;
                e.Cancel = true;
            }
        }

        protected void ListViewCities_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            this.LabelCityErrors.Text = string.Empty;

            try
            {
                string cityName = (this.ListViewCities.Items[e.ItemIndex].FindControl("CityNameTextBox") as TextBox).Text;
                this.ValidateName(cityName);

                float latitude;
                string latitudeAsString = (this.ListViewCities.Items[e.ItemIndex].FindControl("LatitudeTextBox") as TextBox).Text;
                this.ValidateCoordinate(latitudeAsString, out latitude);

                float longitude;
                string longitudeAsString = (this.ListViewCities.Items[e.ItemIndex].FindControl("LongitudeTextBox") as TextBox).Text;
                this.ValidateCoordinate(longitudeAsString, out longitude);

                int population;
                string populationAsString = (this.ListViewCities.Items[e.ItemIndex].FindControl("PopulationTextBox") as TextBox).Text;
                this.ValidatePopulation(populationAsString, out population);
            }
            catch (DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors
                    .SelectMany(eve => eve.ValidationErrors)
                    .Select(ve => ve.ErrorMessage);
                this.LabelCityErrors.Text = string.Join(", ", errors);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                this.LabelCityErrors.Text = ex.Message;
                e.Cancel = true;
            }
        }

        protected void ListViewCities_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            string confirmValue = Request.Form["confirm-value"];

            if (confirmValue == "No")
            {
                e.Cancel = true;
            }
        }













        private string GetFooterRowTextBoxText(GridView grid, string controlId)
        {
            var control = (grid.FooterRow.FindControl(controlId) as TextBox);
            string controlText = Server.HtmlEncode(control.Text);

            return controlText;
        }

        private bool IsValidCountryId(string countryId)
        {
            if (string.IsNullOrWhiteSpace(countryId))
            {
                Response.Write("Please enter Country Id!");
                return false;
            }

            if (countryId.Length > 3)
            {
                Response.Write("Country Id must be 3 symbols or less!");
                return false;
            }

            return true;
        }

        private bool IsValidCountryName(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
            {
                Response.Write("Please enter Country name!");
                return false;
            }

            if (countryName.Length > 50)
            {
                Response.Write("Country name must be 50 symbols or less!");
                return false;
            }

            return true;
        }

        private bool IsValidCountryLanguages(string[] languages)
        {
            WorldEntities db = new WorldEntities();
            Language curLanguage;
            foreach (var language in languages)
            {
                curLanguage = db.Languages.FirstOrDefault(x => x.LanguageName == language);
                if (curLanguage == null)
                {
                    return false;
                }
            }

            return true;
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Missing name.");
            }
        }

        private void ValidateCoordinate(string s, out float result)
        {
            if (!float.TryParse(s, out result))
            {
                throw new ArgumentException("Geo coordinate should be a real number.");
            }
        }

        private void ValidateSurfaceArea(string s, out int result)
        {
            if (!int.TryParse(s, out result) || result <= 0)
            {
                throw new ArgumentException("Surface area should be integer number.");
            }
        }

        private void ValidatePopulation(string s, out int result)
        {
            if (!int.TryParse(s, out result) || result <= 0)
            {
                throw new ArgumentException("The population should be a positive integer.");
            }
        }

        private byte[] GetUploadedFile(HttpPostedFile postedFile)
        {
            if (postedFile != null)
            {
                //Create byte Array with file len
                byte[] data = new Byte[postedFile.ContentLength];

                //force the control to load data in array
                postedFile.InputStream.Read(data, 0, postedFile.ContentLength);

                return data;
            }

            return null;
        }

        private string GetTextBoxText(GridView gridView, int rowIndex, string controlId)
        {
            return (gridView.Rows[rowIndex].FindControl(controlId) as TextBox).Text.Trim();
        }
    }
}