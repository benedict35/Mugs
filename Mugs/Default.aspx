<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mugs._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Mug Simulator</h1>
        <p class="lead">Assign and unassign mugs to workers</p>
    </div>

    <div class="row" style="padding-bottom: 50px; float: right; display: block;">
        <div class="col-md-4">
            <asp:Button ID="take" runat="server" BackColor="#CC66FF" Height="50px" Text="Worker Takes Mug" Width="250px" OnClick="TakeMug" />
            <br />
            <br />
            <asp:Button ID="return" runat="server" BackColor="#CC66FF" Height="50px" Text="Worker Returns Mug" Width="250px" OnClick="ReturnMug" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC66FF" Width="250px" Text="RETURN MESSAGE"></asp:Label>
            <br />
            <asp:Label ID="return_message" runat="server" ForeColor="#CC66FF" Width="250px"></asp:Label>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="row" style="float: left; display: block; width: 100%;">
        <div class="col-md-4">
            
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#CC66FF" Text="DASH BOARD"></asp:Label>
            <br />
            <asp:Label ID="return_message0" runat="server" ForeColor="#CC66FF">Hard Worker:</asp:Label>
&nbsp;<asp:Label ID="hard" runat="server" ForeColor="#CC66FF"></asp:Label>
            <br />
            <asp:Label ID="return_message1" runat="server" ForeColor="#CC66FF">Happy Worker:</asp:Label>
&nbsp;<asp:Label ID="happy" runat="server" ForeColor="#CC66FF"></asp:Label>
            <br />
            <asp:Label ID="return_message2" runat="server" ForeColor="#CC66FF">Hopeless Worker:</asp:Label>
&nbsp;<asp:Label ID="hopeless" runat="server" ForeColor="#CC66FF"></asp:Label>
            <br />
            <br />
            <asp:Label ID="return_message3" runat="server" ForeColor="#CC66FF">Total Mugs Taken: </asp:Label>
            <asp:Label ID="taken" runat="server" ForeColor="#CC66FF"></asp:Label>
            <br />
            <asp:Label ID="return_message4" runat="server" ForeColor="#CC66FF">Total Mugs Available: </asp:Label>
            <asp:Label ID="available" runat="server" ForeColor="#CC66FF"></asp:Label>
            
        </div>
    </div>
    <div class="clearfix"></div>


</asp:Content>
