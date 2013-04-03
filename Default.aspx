<%@ Page  Language="C#"  %>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Button1.Text.Contains("Edit"))
        {
            WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode;
            Button1.Text = "Switch to Browse Mode";
        }
        else
        {
            WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode;
            Button1.Text = "Switch to Edit Mode";
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        int countOfControls = this.WebPartZone2.Controls.Count;
        int countOfWebParts = this.WebPartZone2.WebParts.Count;

        foreach (WebPart wp in this.WebPartZone2.WebParts)
        {
            if (wp is GenericWebPart)
            {
                Type t = ((GenericWebPart)wp).ChildControl.GetType();
                string typeName = t.Name;
            }
        }
    }
</script>
<html>
<body>


<form id="form2" runat="server">

<div id="container" style="width: 725px; height: 366px;">
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <div id="rightpanel" style="float: right">
        <asp:WebPartZone ID="WebPartZone2" runat="server" HeaderText="Middle Zone">
            <ZoneTemplate>
                <asp:Label ID="Label1" runat="server" 
                    Text="We often learn more from our failures than from our successes" 
                    Title="Today's though" Height="33px" Width="458px" ></asp:Label>
            </ZoneTemplate>
        </asp:WebPartZone>
    </div>
    <div id="leftpanel">
        <asp:WebPartZone ID="WebPartZone1" runat="server" HeaderText="Left Zone">
            <ZoneTemplate>
                <asp:Calendar ID="Calendar1" runat="server" Title="Thought of the Day"></asp:Calendar>
            </ZoneTemplate>
        </asp:WebPartZone>
    </div>
</div>
<asp:EditorZone ID="EditorZone1" runat="server">
    <ZoneTemplate>
        <asp:AppearanceEditorPart ID="AppearanceEditorPart1" runat="server" />
    </ZoneTemplate>
</asp:EditorZone>
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
    Text="Switch to Edit Mode" />
</form>

</body>
</html>