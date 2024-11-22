<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicationList.aspx.cs" Inherits="WebApplication7.PublicationList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Makale Listesi</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 80%;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #333;
        }
        .publication-item {
            margin-bottom: 10px;
        }
        .publication-link {
            text-decoration: none;
            color: #007bff;
        }
        .publication-link:hover {
            text-decoration: underline;
        }
        .citation-count {
            color: #28a745;
            font-weight: bold;
        }
        .sort-dropdown {
            margin-bottom: 10px;
            text-align: right;
        }
        .sort-dropdown select {
            padding: 5px;
            font-size: 16px;
            border-radius: 5px;
            background-color: #007bff;
            color: #fff;
            border: none;
            cursor: pointer;
        }
        .sort-dropdown select option {
            background-color: #007bff;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Makale Listesi</h1>
            <div class="sort-dropdown">
                <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSortBy_SelectedIndexChanged">
                    <asp:ListItem Text="En Yakın Tarihe Göre Sırala" Value="closest"></asp:ListItem>
                    <asp:ListItem Text="En Uzak Tarihe Göre Sırala" Value="furthest"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Repeater ID="PublicationRepeater" runat="server">
                <ItemTemplate>
                    <div class="publication-item">
                        <a class="publication-link" href='<%# Eval("Item2") %>' target="_blank"><%# Eval("Item1") %></a>
                        <br />
                        <span><%# Eval("Item3") %></span> <!-- Item3'ü burada göster -->
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
