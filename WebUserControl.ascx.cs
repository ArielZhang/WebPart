using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls.WebParts;

public partial class WebUserControl : System.Web.UI.UserControl, IWebPart, IWebActionable
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        DataTable dt = new DataTable("MeetingData");
        dt.Columns.Add("MeetingName", typeof(string));
        dt.Columns.Add("MeetingDateTime", typeof(DateTime));

        DataRow row1 = dt.NewRow();
        row1["MeetingName"] = "AGM";
        row1["MeetingDateTime"] = DateTime.Now.AddDays(.2);
        dt.Rows.Add(row1);

        DataRow row2 = dt.NewRow();
        row2["MeetingName"] = "AGM";
        row2["MeetingDateTime"] = DateTime.Now.AddDays(.2);
        dt.Rows.Add(row2);

        this.rptMeetings.DataSource = dt;
        this.rptMeetings.DataBind();

    }

    public string CatalogIconImageUrl
    {
        get { return "~/Images/Lion.jpg"; }
        set { return; }
    }

    public string Description
    {
        get { return "this is ariel description"; }
        set { return; }
    }

    public string Subtitle
    {
        get { return "ariel sub title"; }
    }

    public string Title
    {
        get { return "web part tiel"; }
        set { return; }
    }

    public string TitleIconImageUrl
    {
        get { return "~/Images/Lion.jpg"; }
        set { return; }
    }

    public string TitleUrl
    {
        get { return "~/Default.aspx"; }
        set { return; }
    }

    WebPartVerbCollection IWebActionable.Verbs
    {
        get
        {
            WebPartVerb timeVerb = new WebPartVerb("TimeVerb1", new WebPartEventHandler(DisplayTime));

            timeVerb.Text = "change display text";
            timeVerb.ImageUrl = "~/Images/Lion.jpg";

            WebPartVerb clearVerb = new WebPartVerb("ClearVerb1", new WebPartEventHandler(ClearTime));
            clearVerb.Text = "clear display text";
            clearVerb.ImageUrl = "~/Images/Lion.jpg";

            WebPartVerb clientVerb = new WebPartVerb("Client Verb1", "ClientClickHandler('" + this.ClientID + "')");
            clientVerb.Text = "client alert";
            clientVerb.ImageUrl = "~/Images/Lion.jpg";

            return new WebPartVerbCollection(new WebPartVerb[] { timeVerb, clearVerb, clientVerb});
        }
    }

    protected void ClearTime(object sender, WebPartEventArgs e)
    {
        this.Label1.Text = string.Empty;
    }

    protected void DisplayTime(object sender, WebPartEventArgs e)
    {
        this.Label1.Text = DateTime.Now.ToString();
    }


}