using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Connection_NumberProvider : System.Web.UI.UserControl, INumbers
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int[] Numbers
    {
        get
        {
            string[] strings = this.TextBox1.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int[] numbers = new int[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                int tmp;
                if (int.TryParse(strings[i], out tmp))
                {
                    numbers[i] = tmp;
                }
            }

            return numbers;
        }
    }

    [ConnectionProvider("Number Provider", "default")]
    public INumbers GetProviderData()
    {
        return this;
    }
}