<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="admin.aspx.vb" Inherits="FormsAuthVB.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<h1>Administradores</h1>
			<br />
			<asp:Label runat="server" ID="user"></asp:Label>
			<br />
			<asp:HyperLink ID="linkIndex" runat="server" Visible="true" NavigateUrl="~/Vistas/index.aspx">P&aacute;gina Index</asp:HyperLink>
			<br />
			<input type="submit" value="SignOut" runat="server" id="cmdSignOut" />
		</div>
	</form>
</body>
</html>
