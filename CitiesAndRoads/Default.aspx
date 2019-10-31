<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CitiesAndRoads.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Code runners challenge</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-6 col-sm-6">
                <asp:GridView ID="citiesGridView" runat="server" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="CityName" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Label ID="cityLabel" runat="server" Font-Bold="True" Font-Names="Book Antiqua" Text="City Name"></asp:Label>
                <br />
                <asp:TextBox ID="cityNameTextBox" runat="server" Font-Names="Book Antiqua"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="addCityButton" runat="server" OnClick="addCityButton_Click" Text="Add" Width="59px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="cityValidationLabel" runat="server" Font-Bold="True" Font-Names="Book Antiqua" ForeColor="Red"></asp:Label>
                <br />
                <asp:Button ID="logisticCenterButton" runat="server" OnClick="logisticCenterButton_Click" Text="Find logistic center" />
            &nbsp;&nbsp;&nbsp;
                <asp:Label ID="logisticCenterLabel" runat="server" Font-Names="Book Antiqua"></asp:Label>
            </div>
            <div class="col-md-6 col-sm-6">
                <asp:GridView ID="roadsGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Length" HeaderText="Road Length" />
                    </Columns>
                    <Columns>
                        <asp:BoundField DataField="SideCityOneName" HeaderText="City Name 1" />
                    </Columns>
                    <Columns>
                        <asp:BoundField DataField="SideCityTwoName" HeaderText="City Name 2" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Label ID="roadLengthLabel" runat="server" Font-Bold="True" Font-Names="Book Antiqua" Text="Road length(km)"></asp:Label>
                <br />
                <asp:TextBox ID="roadLengthTextBox" runat="server" Font-Names="Book Antiqua" TextMode="Number"></asp:TextBox>
                <br />
                Between
                <asp:DropDownList ID="cityOneDropDownList" runat="server" Font-Names="Book Antiqua" AutoPostBack="True"></asp:DropDownList>
                and
                <asp:DropDownList ID="cityTwoDropDownList" runat="server" Font-Names="Book Antiqua" AutoPostBack="True"></asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="addRoadButton" runat="server" OnClick="addRoadButton_Click" Text="Add" Width="59px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="roadValidationLabel" runat="server" Font-Bold="True" Font-Names="Book Antiqua" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
    </form>

    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
