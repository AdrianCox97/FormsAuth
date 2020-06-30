<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="logon.aspx.vb" Inherits="FormsAuthVB.logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<h3>
				<font face="Verdana">Logon Page</font>
			</h3>
			<table>
				<tr>
					<td>Email:</td>
					<td>
						<input id="txtUserName" type="text" runat="server" /></td>
					<td>
						<asp:RequiredFieldValidator ControlToValidate="txtUserName"
							Display="Static" ErrorMessage="*" runat="server"
							ID="vUserName" /></td>
				</tr>
				<tr>
					<td>Password:</td>
					<td>
						<input id="txtUserPass" type="password" runat="server" /></td>
					<td>
						<asp:RequiredFieldValidator ControlToValidate="txtUserPass"
							Display="Static" ErrorMessage="*" runat="server"
							ID="vUserPass" />
					</td>
				</tr>
				<tr>
					<td>Persistent Cookie:</td>
					<td>
						<asp:CheckBox ID="chkPersistCookie" runat="server" AutoPostBack="false" /></td>
					<td></td>
				</tr>
			</table>
			<input type="submit" value="Logon" runat="server" id="cmdLogin" /><p></p>
			<asp:Label ID="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
		</div>
	</form>
</body>
</html>
