using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
/// Summary description for WebPartTests
/// </summary>

namespace WebPartTests
{
    public class CustomWeatherPart : WebPart 
    {
        public CustomWeatherPart()
        {

        }

        public int NumberofDays
        {
            get
            {
                if (ViewState["NumberofDays"] == null)
                {
                    return 4;
                }
                else
                {
                    return (int)ViewState["NumberofDays"];
                }
            }

            set
            {
                if (value < 1 || value > 10)
                {
                    ViewState["NumberofDays"] = 4;
                }
                else
                {
                    ViewState["NumberofDays"] = value;
                }
            }
        }

        private enum WeatherType
        {
            Sunny = 0,
            Rainy = 1,
            Cloudy = 2,
            Unknown = int.MaxValue
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);

            Random rand = new Random();

            for (int i = 0; i < this.NumberofDays; i++)
            {
                int weatherValue = rand.Next(1000) % 3;
                WeatherType todayWeather = (WeatherType)weatherValue;

                Image img = new Image();
                img.ImageUrl = "~/Images/Lion.jpg";
                img.AlternateText = "Today's weather";

                writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                img.RenderControl(writer);
                writer.WriteBreak();
                writer.Write(todayWeather.ToString());
                writer.RenderEndTag();

            }
        }

        public override EditorPartCollection CreateEditorParts()
        {
            EditorPart zip = new ZipCodeSelector();
            zip.ID = "editor1";
            Object[] editors = new Object[] { zip }; 
            return new EditorPartCollection(editors);
        }

    }


    public class ZipCodeSelector : EditorPart
    {
        protected TextBox m_tbUsername;
        protected TextBox m_tbSearchString;

        protected override void CreateChildControls()
        {
            // Add controls here
            m_tbUsername = new TextBox();
            m_tbSearchString = new TextBox();
            this.Controls.Add(new LiteralControl("<br/><b>Username</b><br/>"));
            this.Controls.Add(m_tbUsername);
            this.Controls.Add(new LiteralControl("<br/><b>Search string</b><br/>"));
            this.Controls.Add(m_tbSearchString);

            base.CreateChildControls();
            this.ChildControlsCreated = true;
        }

        public override void SyncChanges()
        {
            EnsureChildControls();
            CustomWeatherPart custom = (CustomWeatherPart)this.WebPartToEdit;
            if (custom != null)
            {
                m_tbUsername.Text = custom.NumberofDays.ToString();
            }
            return;
        }

        public override bool ApplyChanges()
        {
            EnsureChildControls();
            CustomWeatherPart custom = (CustomWeatherPart)this.WebPartToEdit;
            if (custom != null)
            {
                custom.NumberofDays = Convert.ToInt32(m_tbUsername.Text);
            }
            return true;
        }

    }
}
