<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register TagPrefix="wp" Namespace="WebPartTests" %>

<%@ Register src="WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" >
    </asp:WebPartManager>
    <div>
    
        <asp:WebPartZone ID="WebPartZone1" runat="server">
            <ZoneTemplate>
                <wp:CustomWeatherPart
                    ID="CustomerWeatherPart1" runat="server" NumberofDays="6" Title="Weather Forcast" />
            </ZoneTemplate>
        </asp:WebPartZone>
        <asp:EditorZone ID="EditorZone1" runat="server">
        </asp:EditorZone>
    </div>
    <asp:WebPartZone ID="WebPartZone2" runat="server">
        <ZoneTemplate>
            <uc1:WebUserControl ID="WebUserControl1" runat="server" />
        </ZoneTemplate>
    </asp:WebPartZone>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
        Text="Button" />
    </form>
</body>
</html>
