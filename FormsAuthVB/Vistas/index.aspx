<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="FormsAuthVB.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<h1>Index</h1>
			<br />
			<asp:Label runat="server" ID="user"></asp:Label>
			<br />
			<asp:Label runat="server" ID="rol"></asp:Label>
			<br />
			<asp:HyperLink ID="linkAdmin" runat="server" Visible="false" NavigateUrl="~/Vistas/admin.aspx">P&aacute;gina Admin</asp:HyperLink>
			<br />
			<asp:HyperLink ID="linkProveeedores" runat="server" Visible="false" NavigateUrl="~/Vistas/proveedores.aspx">P&aacute;gina Proveedores</asp:HyperLink>
			<br />
			<input type="submit" value="SignOut" runat="server" id="cmdSignOut" />
		</div>
	</form>
</body>
</html>
