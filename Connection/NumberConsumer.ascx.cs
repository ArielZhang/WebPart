using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;

public partial class Connection_NumberConsumer : System.Web.UI.UserControl
{
    private INumbers _data = null;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    Color[] _colors = new Color[] {
        Color.Blue,
        Color.Green,
        Color.Red,
        Color.Gold};

    [ConnectionConsumer("Text Consumer")]
    public void SetProviderData(INumbers providerData)
    {
        this._data = providerData;
    }
}