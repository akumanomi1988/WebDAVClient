Imports System.IO
Imports System.Net
Imports System.Text
Imports WinSCP
Public Class API
	Const HostName As String = "192.168.0.38"
	Const InitialPath As String = "http://192.168.0.38"
	Const UsersUri As String = "/ocs/v1.php/cloud/users"
	Const SearchUri As String = "?search"
	Const InitialPathRelative As String = "/remote.php/dav/files/"
	Private _user As String
	Public Property User() As String
		Get
			Return _user
		End Get
		Set(ByVal value As String)
			_user = value
		End Set
	End Property
	Private _Pass As String
	Public Property Pass() As String
		Get
			Return _Pass
		End Get
		Set(ByVal value As String)
			_Pass = value
		End Set
	End Property
	Private _Session As New Session
	Public ReadOnly Property Session() As Session
		Get
			Return _Session
		End Get
	End Property
	Private _SessionOptions As New SessionOptions
	Public ReadOnly Property SessionOptions() As SessionOptions
		Get
			Return _SessionOptions
		End Get
	End Property
	Protected Overrides Sub Finalize()
		_SessionOptions = Nothing
		_Session = Nothing
		MyBase.Finalize()
	End Sub
	Public Sub New()
	End Sub
	Public Function Connect(UserName As String, Password As String) As String
		User = UserName
		Pass = Password
		With _SessionOptions
			.Protocol = Protocol.Webdav
			.HostName = HostName
			.UserName = _user
			.Password = _Pass
			.RootPath = InitialPathRelative & UserName
		End With
		Return Me.pConnect
	End Function
	Private Function pConnect() As String
		If _Session.Opened Then
			Return "CONNECTED"
		Else
			_Session.Open(SessionOptions)
			If _Session.Opened Then
				Return "CONNECTED"
			Else Return "DISCONNECTED"
			End If
		End If
	End Function
	Public Function PutFiles(Full_Path_Origin As String, Relative_Path_Destiny As String, Optional versionar As Boolean = True) As String
		Dim resp As String = String.Empty
		Dim transferOptions As New TransferOptions
		Dim TransferResult As TransferOperationResult
		If Relative_Path_Destiny.First <> "/" Then Throw New ArgumentException(Relative_Path_Destiny & " Must start with '/'.")
		If Not File.Exists(Full_Path_Origin) Then Throw New ArgumentException(Full_Path_Origin & " Must exist.")
		If Not _Session.Opened Then pConnect()
		Try
			transferOptions.TransferMode = TransferMode.Automatic
			If versionar Then
				transferOptions.OverwriteMode = OverwriteMode.Append
			Else
				transferOptions.OverwriteMode = OverwriteMode.Overwrite
			End If
			TransferResult = _Session.PutFiles(Full_Path_Origin, InitialPath & _SessionOptions.RootPath & Relative_Path_Destiny, False, transferOptions)
			TransferResult.Check()
			For Each transfer In TransferResult.Transfers
				resp &= transfer.FileName & Environment.NewLine
			Next
			Return resp
		Catch ex As Exception
			Return "ERROR"
		End Try
	End Function
	Public Function GetFiles(Full_Path_Destiny As String, Relative_Path_Origin As String) As String
		Dim resp As String = String.Empty
		Dim transferOptions As New TransferOptions
		Dim TransferResult As TransferOperationResult
		If Relative_Path_Origin.First <> "/" Then Throw New ArgumentException(Relative_Path_Origin & " Must start with '/'")
		If Not _Session.Opened Then pConnect()
		Try
			transferOptions.TransferMode = TransferMode.Binary
			TransferResult = _Session.GetFiles(InitialPath & _SessionOptions.RootPath & Relative_Path_Origin, Full_Path_Destiny, True, transferOptions)
			TransferResult.Check()
			For Each transfer As TransferEventArgs In TransferResult.Transfers
				resp &= transfer.FileName & Environment.NewLine
			Next
			Return resp
		Catch ex As Exception
			Return "ERROR"
		End Try
	End Function
	Public Function OpenFile(Full_Path_Destiny As String, Relative_Path_Origin As String) As String
		Dim resp As String
		resp = GetFiles(Full_Path_Destiny, Relative_Path_Origin)
		ChangeFileProtectionState(Relative_Path_Origin, False)
		If File.Exists(Full_Path_Destiny) And resp <> "ERROR" Then
			Using p As New Process
				p.StartInfo.FileName = Full_Path_Destiny
				p.StartInfo.UseShellExecute = True
				p.StartInfo.RedirectStandardOutput = False
				p.Start()
				p.WaitForExit()
			End Using
			resp &= PutFiles(Full_Path_Destiny, Relative_Path_Origin)
			ChangeFileProtectionState(Relative_Path_Origin, True)
		End If
		Return resp
	End Function
	Private Function ChangeFileProtectionState(ElementPath As String, protect As Boolean)
		Return True
	End Function
	Public Function CreateUser(myUser As String, myPass As String, Name As String, Password As String, email As String, group As String) As String
		Dim cred As New NetworkCredential(myUser, myPass)
		Dim headercollection As New WebHeaderCollection
		headercollection.Add("userid", Name)
		headercollection.Add("password", Password)
		headercollection.Add("group", group)
		headercollection.Add("email", email)
		Using reader As New StreamReader(REST_POST(InitialPath & UsersUri, cred, headercollection).GetResponseStream)
			Return reader.ReadToEnd()
		End Using
	End Function
	Public Function GetUsers(myUser As String, myPass As String) As String
		Dim cred As New NetworkCredential(myUser, myPass)
		Dim headercollection As New WebHeaderCollection
		Using reader As New StreamReader(REST_GET(InitialPath & UsersUri & SearchUri, cred, headercollection).GetResponseStream)
			Return reader.ReadToEnd()
		End Using
	End Function
	Private Function REST_POST(restURL As String, credential As NetworkCredential, Optional headerColl As WebHeaderCollection = Nothing) As HttpWebResponse
		Try
			Dim request As HttpWebRequest = WebRequest.Create(restURL)
			request.PreAuthenticate = True
			request.Credentials = credential
			If headerColl IsNot Nothing Then request.Headers = headerColl
			request.Method = "POST"
			request.ContentType = "text/plain"
			Return request.GetResponse()
		Catch ex As Exception
			Return Nothing
		End Try
	End Function
	Private Function REST_GET(restURL As String, credential As NetworkCredential, Optional headerColl As WebHeaderCollection = Nothing) As HttpWebResponse
		Try
			Dim request As HttpWebRequest = WebRequest.Create(restURL)
			request.PreAuthenticate = True
			request.Credentials = credential
			If headerColl IsNot Nothing Then request.Headers = headerColl
			request.Method = "GET"
			request.ContentType = "text/plain"
			Return request.GetResponse()
		Catch ex As Exception
			Return Nothing
		End Try
	End Function
	Public Function EnumerateFiles(relative_path As String) As String
		Dim resp As String = String.Empty
		Dim list As IEnumerable(Of RemoteFileInfo)
		If relative_path.First <> "/" Then Throw New ArgumentException(relative_path & " Must start with '/'")
		If Not _Session.Opened Then pConnect()
		Try
			list = _Session.EnumerateRemoteFiles(InitialPath & InitialPathRelative, Nothing, EnumerationOptions.AllDirectories)
			For Each item In list
				resp &= item.Name & Environment.NewLine
			Next
			Return resp
		Catch ex As Exception
			Return "ERROR"
		End Try
	End Function
End Class
