<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestHome.aspx.cs" Inherits="RevizijaAPI.Pages.TestHome" %>

<%@ Register assembly="DevExpress.Web.v19.1, Version=19.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 { 
            height: 319px;
            text-align: center;
        }
        #container{
            text-align: center;
        }
        #textBoxUsername{
            display:block;
        }
        .center {
            text-align: center;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: 10px;

        }
    </style>


</head>
<body style="height: 560px" >
    <form id="form1" runat="server">
        <h1>Login</h1>
        <div id="container" class="center" >
            <dx:ASPxTextBox ID="textBoxUsername" runat="server" Width="170px"  Theme="iOS" CssClass="center">
            </dx:ASPxTextBox>
            <dx:ASPxTextBox ID="textBoxPassword" runat="server" Width="170px"  Theme="iOS" CssClass ="center" Password="true">
            </dx:ASPxTextBox>
            <dx:ASPxButton ID="btnLogin" runat="server" Text="LOG IN" Theme="iOS" CssClass ="center" OnClick="btnLogin_Click">
            </dx:ASPxButton>
            <dx:ASPxLabel ID="labelResult" runat="server" Text="..." CssClass="center">
            </dx:ASPxLabel>
        </div>


    </form>
</body>
</html>
