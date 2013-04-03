<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>


<h3>Current Date and Time</h3>
<div>
    <span style="width: 140px">Date: </span>
    <%= DateTime.Now.ToShortDateString() %>
</div>

<div>
    <span style="width: 140px">Time: </span>
    <%= DateTime.Now.ToShortTimeString() %>
</div>

<h3>Upcoming Meetings</h3>
<asp:Repeater ID="rptMeetings" runat="server">
    <ItemTemplate>
        <p>
            <b><%# Eval("MeetingName") %></b>
            <br />
            <span style="font-size: smaller; font-style: italic;">
                <%# Eval("MeetingDateTime") %>
            </span>
        </p>
    </ItemTemplate>
</asp:Repeater>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>


<script language = "javascript" type="text/javascript">
    function ClientClickHandler(webpartid) {
        alert(" you clicked the following web part: " + webpartid + ".");
    }
</script>