using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode;
    }
}