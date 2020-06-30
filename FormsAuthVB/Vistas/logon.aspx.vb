Imports System.Data.SqlClient
Imports Newtonsoft.Json

Public Class logon
	Inherits System.Web.UI.Page

	Dim usuario As Usuario
	Dim datosUsuario As String = Nothing
	Dim administrador As Char = "A"
	Dim proveedor As Char = "P"

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub

	Private Sub cmdLogin_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin.ServerClick
		If ValidateUser(txtUserName.Value, txtUserPass.Value) Then
			Dim tkt As FormsAuthenticationTicket
			Dim cookiestr As String
			Dim ck As HttpCookie

			datosUsuario = JsonConvert.SerializeObject(usuario)
			tkt = New FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now, DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, datosUsuario)
			cookiestr = FormsAuthentication.Encrypt(tkt)
			ck = New HttpCookie(FormsAuthentication.FormsCookieName, cookiestr)

			If chkPersistCookie.Checked Then ck.Expires = tkt.Expiration

			ck.Path = FormsAuthentication.FormsCookiePath

			Response.Cookies.Add(ck)

			Dim strRedirect As String = String.Empty

			'If usuario.rol.Equals(administrador) Then
			'	strRedirect = "~/Vistas/admin.aspx"
			'ElseIf usuario.rol.Equals(proveedor) Then
			'	strRedirect = "~/Vistas/proveedores.aspx"
			'End If

			strRedirect = "~/Vistas/index.aspx"

			Response.Redirect(strRedirect, True)
		Else
			Response.Redirect("~/Vistas/logon.aspx", True)
		End If
	End Sub

	Private Function ValidateUser(ByVal userName As String, ByVal passWord As String) As Boolean
		Dim conn As SqlConnection
		Dim cmd As SqlCommand
		Dim reader As SqlDataReader

		If (userName Is Nothing) OrElse (0 = userName.Length) OrElse (userName.Length > 15) Then
			System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
			Return False
		End If

		If (passWord Is Nothing) OrElse (0 = passWord.Length) OrElse (passWord.Length > 25) Then
			System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
			Return False
		End If

		Try
			conn = New SqlConnection("server=localhost;Integrated Security=SSPI;database=pruebas")
			conn.Open()
			cmd = New SqlCommand("Select uname, pwd, userRole from users where uname=@userName", conn)
			cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25)
			cmd.Parameters("@userName").Value = userName
			reader = cmd.ExecuteReader()

			usuario = New Usuario

			While reader.Read()
				usuario.uname = reader("uname").ToString()
				usuario.pwd = reader("pwd").ToString()
				usuario.rol = reader("userRole").ToString()
			End While
			cmd.Dispose()
			conn.Dispose()
		Catch ex As Exception
			System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " & ex.Message)
		End Try

		If usuario.pwd Is Nothing Then
			Return False
		End If

		Return (0 = String.Compare(usuario.pwd, passWord, False))
	End Function
End Class