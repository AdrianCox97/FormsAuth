Imports Newtonsoft.Json

Public Class proveedores
	Inherits System.Web.UI.Page

	Dim administrador As Char = "A"
	Dim proveedor As Char = "P"

	Public Shared strUser As String

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If HttpContext.Current.User.Identity.IsAuthenticated Then
			Dim identity As FormsIdentity = HttpContext.Current.User.Identity
			Dim usuario As Usuario = JsonConvert.DeserializeObject(Of Usuario)(identity.Ticket.UserData)

			If Not usuario.rol.Equals(administrador) And Not usuario.rol.Equals(proveedor) Then
				Response.Redirect("~/Vistas/index.aspx", True)
			End If

			user.Text = "Hola " + usuario.uname
		Else
			Response.Redirect("~/Vistas/logon.aspx", True)
		End If
	End Sub

	Private Sub cmdSignOut_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSignOut.ServerClick
		FormsAuthentication.SignOut()
		Response.Redirect("~/Vistas/logon.aspx", True)
	End Sub
End Class