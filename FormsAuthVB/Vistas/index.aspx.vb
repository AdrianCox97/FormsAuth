Imports Newtonsoft.Json

Public Class index
	Inherits System.Web.UI.Page

	Dim administrador As Char = "A"
	Dim proveedor As Char = "P"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If HttpContext.Current.User.Identity.IsAuthenticated Then
			Dim identity As FormsIdentity = HttpContext.Current.User.Identity
			Dim usuario As Usuario = JsonConvert.DeserializeObject(Of Usuario)(identity.Ticket.UserData)

			If usuario.rol.Equals(administrador) Then
				linkAdmin.Visible = True
				linkProveeedores.Visible = True
			ElseIf usuario.rol.Equals(proveedor) Then
				linkAdmin.Visible = False
				linkProveeedores.Visible = True
			End If

			user.Text = "Usuario: " + usuario.uname
			rol.Text = "Rol: " + usuario.rol
		Else
			Response.Redirect("~/Vistas/logon.aspx", True)
		End If
	End Sub

	Private Sub cmdSignOut_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSignOut.ServerClick
		FormsAuthentication.SignOut()
		Response.Redirect("~/Vistas/logon.aspx", True)
	End Sub
End Class