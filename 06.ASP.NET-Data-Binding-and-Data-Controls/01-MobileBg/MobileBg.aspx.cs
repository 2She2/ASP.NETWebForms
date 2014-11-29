using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_MobileBg
{
    public partial class MobileBg : System.Web.UI.Page
    {
        public List<Producer> Producers
        {
            get
            {
                return new List<Producer>
                {
                    new Producer{Name= string.Empty},
                    new Producer{Name = "Mercedes", Models = new List<string>{"C-class", "E-class", "S-class"}},
                    new Producer{Name = "BMW", Models = new List<string>{"3-series", "5-series", "7-series"}},
                    new Producer{Name = "Audi", Models = new List<string>{"A4", "A6", "A8"}}
                };
            }
        }

        public List<Extra> extras = new List<Extra>
        {
            new Extra("Air Conditioning"),
            new Extra("Electric Mirrors"),
            new Extra("Schiebedach"),
            new Extra("Automatic Transmission"),
            new Extra("Self-Heating Seats"),
            new Extra("Satnav"),
            new Extra("Parktronic"),
            new Extra("Cruise Control")
        };

        public string[] engines = { "Petrol",
                                    "Diesel",
                                    "Electric",
                                    "Hybrid"
                                  };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            this.DropDownListProducers.DataSource = this.Producers;
            this.RadioButtonListEngines.DataSource = this.engines;

            this.DataBind();
        }

        protected void DropDownListProducers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProducer = this.DropDownListProducers.SelectedItem.ToString();
            string models = this.DropDownListProducers.SelectedValue.ToString();

            var currentModels = this.Producers.Where(x => x.Name == selectedProducer).Select(x => x.Models).First();
            this.DropDownListModels.DataSource = currentModels;
            this.DropDownListModels.DataBind();
        }

        protected void DropDownListModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedModel = this.DropDownListModels.SelectedItem.ToString();
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string producer = "Not selected";
            if (this.DropDownListProducers.SelectedItem != null && !string.IsNullOrEmpty(this.DropDownListProducers.SelectedItem.Text))
            {
                producer = Server.HtmlEncode(this.DropDownListProducers.SelectedItem.Text);
            }

            string model = "Not selected";
            if (this.DropDownListModels.SelectedItem != null && !string.IsNullOrEmpty(this.DropDownListModels.SelectedItem.Text))
            {
                model = Server.HtmlEncode(this.DropDownListModels.SelectedItem.Text);
            }

            string engineType = "Not selected";
            if (this.RadioButtonListEngines.SelectedItem != null && !string.IsNullOrEmpty(this.RadioButtonListEngines.SelectedItem.Text))
            {
                engineType = Server.HtmlEncode(this.RadioButtonListEngines.SelectedItem.Text);
            }
            
            IList<string> extras = this.GetSelectedExtras();

            StringBuilder result = new StringBuilder();
            result.AppendFormat("Producer: <strong>{0}</strong><br />", producer);
            result.AppendFormat("Model: <strong>{0}</strong><br />", model);
            result.AppendFormat("Engine: <strong>{0}</strong><br />", engineType);
            result.Append("Extras:<br />");

            if (extras.Count == 0)
            {
                result.Append("<strong>No extras selected</strong><br />");
            }
            else
            {
                for (int i = 0; i < extras.Count; i++)
                {
                    result.AppendFormat("<strong>{0}</strong><br />", extras[i]);
                }
            }

            this.LiteralSubmitedInfo.Text = result.ToString();
        }

        private IList<string> GetSelectedExtras()
        {
            List<string> extras = new List<string>();

            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
            {
                var currCheckBox = this.CheckBoxListExtras.Items[i];

                if (currCheckBox.Selected)
                {
                    extras.Add(Server.HtmlEncode(currCheckBox.Text));
                }
            }

            return extras;
        }
    }
}