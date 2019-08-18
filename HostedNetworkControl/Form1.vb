Imports System.Net
Imports System.Net.NetworkInformation
Public Class Form1
    Dim InSetup As Boolean = True
    Dim IPF As New IPComp

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim ThreadHandles As New Threading.Thread(AddressOf SeperateThreadhandles)
        ThreadHandles.Start()
    End Sub
    Public Sub SeperateThreadhandles()
        Dim FR As New Threading.Thread(AddressOf InitialStartSetup)
        FR.Start()
        BKDataUpdater.RunWorkerAsync()
        IPF.Ping_all()
        BKPinger.RunWorkerAsync()
    End Sub
    Public Sub InitialStartSetup()
        Dim MyNetworkData As NetworkData = GetNetworkData()
        TxtSSID.Text = MyNetworkData.SSID
        TxtPassword.Text = MyNetworkData.UserKey
        CbKeyIsTemp.Checked = Not MyNetworkData.KeyUsage.ToLower = "persistent"
        CBAllowHostedNetwork.Checked = MyNetworkData.Mode = "Allowed"
        Threading.Thread.Sleep(100)
        InSetup = False
    End Sub

    Private Sub BKDataUpdater_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BKDataUpdater.DoWork
        Do Until False
            Dim MyNetworkData As NetworkData = GetNetworkData()
            LblSSID.Text = String.Format("{0}: {1}", "SSID", MyNetworkData.SSID)
            LblBSSID.Text = String.Format("{0}: {1}", "BSSID", MyNetworkData.BSSID)
            LblMaxClients.Text = String.Format("{0}: {1}", "Max Clients", MyNetworkData.MaxClients)
            LblAuth.Text = String.Format("{0}: {1}", "Authentification", MyNetworkData.Authentication)
            LblCipher.Text = String.Format("{0}: {1}", "Cipher", MyNetworkData.Cipher)
            GBStatus.Text = String.Format("{0}: {1}", "Status", MyNetworkData.Status)



            Dim ClassRows As New List(Of ClassRow)
            For Each client In MyNetworkData.Clients
                Dim altmac As String = client.MACAddress.Replace(":", "-")
                Dim IP As String = "Resolving..."
                Dim HOST As String = "Resolving..."
                For Each entry In IPF.connectedIPAddresses
                    If altmac = entry.MacAddress Then
                        IP = entry.IpAddress
                        HOST = entry.HostName
                    End If
                Next
                Dim NR As New ClassRow(client.Auth, HOST, IP, client.MACAddress)
                ClassRows.Add(NR)


            Next

            Dim Unedited As New List(Of ClassRow)
            For Each row As DataGridViewRow In DGCClients.Rows
                Dim Mac As String = row.Cells(0).Value
                Dim IP As String = row.Cells(1).Value
                Dim Host As String = row.Cells(2).Value
                Dim Auth As String = row.Cells(3).Value
                Dim NR As New ClassRow(Auth, Host, IP, Mac)
                Unedited.Add(NR)
            Next



            Dim ToAdd As New List(Of ClassRow)
            Dim ToRemove As New List(Of ClassRow)
            For Each CR In ClassRows
                If Not ListContainsClassrow(Unedited, CR) Then
                    ToAdd.Add(CR)
                End If
            Next
            For Each CR In Unedited
                If Not ListContainsClassrow(ClassRows, CR) Then
                    ToRemove.Add(CR)
                End If
            Next


            If ToAdd.Count <> 0 Then
                IPF.Ping_all()
                Console.WriteLine("Adding {0} Rows...", ToAdd.Count)
                For Each row In ToAdd
                    DGCClients.Rows.Add(row.MAC, row.IP, row.HOST, row.Auth, "Querying...")
                Next
            End If



            If ToRemove.Count <> 0 Then
                Console.WriteLine("Removing {0} Rows...", ToRemove.Count)

                For Each RemoveItem In ToRemove
                    For Each row As DataGridViewRow In DGCClients.Rows
                        Dim Mac As String = row.Cells(0).Value
                        Dim IP As String = row.Cells(1).Value
                        Dim Host As String = row.Cells(2).Value
                        Dim Auth As String = row.Cells(3).Value
                        Dim NR As New ClassRow(Auth, Host, IP, Mac)
                        If CompareClassRows(NR, RemoveItem) Then
                            DGCClients.Rows.RemoveAt(row.Index)
                            Exit For
                        End If
                    Next
                Next




            End If
            Threading.Thread.Sleep(2000)
        Loop
    End Sub

    Public Function CompareClassRows(Classrow1 As ClassRow, Classrow2 As ClassRow) As Boolean
        Return Classrow1.ID = Classrow2.ID
    End Function
    Public Function ListContainsClassrow(ClassList As List(Of ClassRow), ComapreClassRow As ClassRow)
        Dim Found As Boolean = False
        For Each classrow In ClassList
            If classrow.ID = ComapreClassRow.ID Then
                Found = True
            End If
        Next
        Return Found
    End Function


    Public Function GetNetworkData() As NetworkData
        Dim SP As New ProcessStartInfo With {
                .FileName = "netsh.exe",
                .Arguments = "wlan show hostednetwork",
                .UseShellExecute = False,
                .CreateNoWindow = True,
                .RedirectStandardInput = True,
                .RedirectStandardOutput = True,
                .WindowStyle = ProcessWindowStyle.Hidden
            }
        Dim Myprocess As Process = Process.Start(SP)

        Dim NewNetworkProcess As New NetworkData
        Dim isInClientRegion As Boolean = False

        Do Until Myprocess.StandardOutput.EndOfStream
            Dim RL As String = Myprocess.StandardOutput.ReadLine
            If Not RL = "" Then
                Dim NL As String = RL.Trim(" ")
                Dim HasArg As Boolean = False
                Dim FirstArg As String = ""
                Try
                    FirstArg = NL.Split(" ")(0).ToLower
                    HasArg = True
                Catch ex As Exception
                    HasArg = False
                End Try

                Dim hasSArg As Boolean = False
                Dim SeccondaryArgument As String = ""
                Try
                    Dim splitags As List(Of String) = RL.Split(":").ToList
                    splitags.RemoveAt(0)
                    SeccondaryArgument = String.Join(":", splitags)
                    SeccondaryArgument.Trim(" ").Replace(ChrW(32), "")
                    SeccondaryArgument = SeccondaryArgument.Trim(ChrW(32))
                    hasSArg = True
                Catch ex As Exception
                    hasSArg = False
                End Try

                If HasArg And hasSArg Then
                    If Not isInClientRegion Then
                        Select Case FirstArg
                            Case "mode"
                                NewNetworkProcess.Mode = SeccondaryArgument
                            Case "ssid"
                                NewNetworkProcess.SSID = SeccondaryArgument.Replace("""", "")
                            Case "max"
                                NewNetworkProcess.MaxClients = SeccondaryArgument
                            Case "authentication"
                                NewNetworkProcess.Authentication = SeccondaryArgument
                            Case "cipher"
                                NewNetworkProcess.Cipher = SeccondaryArgument
                            Case "status"
                                NewNetworkProcess.Status = SeccondaryArgument
                            Case "bssid"
                                NewNetworkProcess.BSSID = SeccondaryArgument
                            Case "radio"
                                NewNetworkProcess.RadioType = SeccondaryArgument
                            Case "channel"
                                NewNetworkProcess.Channel = SeccondaryArgument
                            Case "number"
                                NewNetworkProcess.ClientCount = SeccondaryArgument
                                isInClientRegion = True
                        End Select
                    Else
                        Try
                            Dim LT As String = NL
                            LT = LT.Replace("        ", ChrW(13))
                            NewNetworkProcess.Clients.Add(New NetworkClient(LT.Split(ChrW(13))(0), LT.Split(ChrW(13))(1)))
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
        Loop
        Dim NetworkLayerProcessStart As New ProcessStartInfo With {
                .FileName = "netsh.exe",
                .Arguments = "wlan show hostednetwork setting=security",
                .UseShellExecute = False,
                .CreateNoWindow = True,
                .RedirectStandardInput = True,
                .RedirectStandardOutput = True,
                .WindowStyle = ProcessWindowStyle.Hidden
            }
        Dim NetworkLayerPorc As Process = Process.Start(NetworkLayerProcessStart)
        Do Until NetworkLayerPorc.StandardOutput.EndOfStream
            Dim RL As String = NetworkLayerPorc.StandardOutput.ReadLine
            RL = RL.Trim(" ")
            If RL.Contains(":") Then
                Select Case RL.Split(":")(0).Trim(" ")
                    Case "System security key"
                        NewNetworkProcess.SystemSecurityKey = RL.Split(":")(1).Trim(" ")
                    Case "User security key"
                        NewNetworkProcess.UserKey = RL.Split(":")(1).Trim(" ")
                    Case "User security key usage"
                        NewNetworkProcess.KeyUsage = RL.Split(":")(1).Trim(" ")
                End Select
            End If
        Loop
        Return NewNetworkProcess
    End Function

    Private Sub BtnShowPassword_Click(sender As Object, e As EventArgs) Handles BtnShowPassword.Click
        If BtnShowPassword.Text = "//" Then
            TxtPassword.PasswordChar = ""
            BtnShowPassword.Text = "\\"
        Else
            BtnShowPassword.Text = "//"
            TxtPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub BtnStartNetwork_Click(sender As Object, e As EventArgs) Handles BtnStartNetwork.Click
        Dim CommandBaseProcess As New ProcessStartInfo With {
               .FileName = "netsh.exe",
               .Arguments = "wlan start hostednetwork",
               .UseShellExecute = False,
               .CreateNoWindow = True,
               .RedirectStandardInput = True,
               .RedirectStandardOutput = True,
               .WindowStyle = ProcessWindowStyle.Hidden
           }
        Process.Start(CommandBaseProcess)
    End Sub

    Private Sub BtnStopNetwork_Click(sender As Object, e As EventArgs) Handles BtnStopNetwork.Click
        Dim CommandBaseProcess As New ProcessStartInfo With {
       .FileName = "netsh.exe",
       .Arguments = "wlan stop hostednetwork",
       .UseShellExecute = False,
       .CreateNoWindow = True,
       .RedirectStandardInput = True,
       .RedirectStandardOutput = True,
       .WindowStyle = ProcessWindowStyle.Hidden
   }
        Process.Start(CommandBaseProcess)
    End Sub

    Private Sub BtnRestartNetwork_Click(sender As Object, e As EventArgs) Handles BtnRestartNetwork.Click
        Dim ST As New Threading.Thread(AddressOf RestartNetwork)
        ST.Start()
    End Sub

    Public Sub RestartNetwork()
        Dim CommandBaseProcess As New ProcessStartInfo With {
       .FileName = "netsh.exe",
       .Arguments = "wlan stop hostednetwork",
       .UseShellExecute = False,
       .CreateNoWindow = True,
       .RedirectStandardInput = True,
       .RedirectStandardOutput = True,
       .WindowStyle = ProcessWindowStyle.Hidden
   }
        Dim CMBa As New ProcessStartInfo With {
           .FileName = "netsh.exe",
           .Arguments = "wlan start hostednetwork",
           .UseShellExecute = False,
           .CreateNoWindow = True,
           .RedirectStandardInput = True,
           .RedirectStandardOutput = True,
           .WindowStyle = ProcessWindowStyle.Hidden
       }

        Process.Start(CommandBaseProcess)
        Threading.Thread.Sleep(500)
        Process.Start(CMBa)
    End Sub
#Region "SaveRaisers"
    Private Sub CmBAuth_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Not InSetup Then
            BtnApplySettings.Text = "Apply Setting Changes*"
        End If
    End Sub

    Private Sub CmBCipher_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Not InSetup Then
            BtnApplySettings.Text = "Apply Setting Changes*"
        End If
    End Sub

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtPassword.TextChanged
        If Not InSetup Then
            BtnApplySettings.Text = "Apply Setting Changes*"
        End If
    End Sub

    Private Sub TxtSSID_TextChanged(sender As Object, e As EventArgs) Handles TxtSSID.TextChanged
        If Not InSetup Then
            BtnApplySettings.Text = "Apply Setting Changes*"
        End If
    End Sub

    Private Sub CBAllowHostedNetwork_CheckedChanged(sender As Object, e As EventArgs) Handles CBAllowHostedNetwork.CheckedChanged
        If Not InSetup Then
            BtnApplySettings.Text = "Apply Setting Changes*"
        End If
    End Sub

    Private Sub CbKeyIsTemp_CheckedChanged(sender As Object, e As EventArgs) Handles CbKeyIsTemp.CheckedChanged
        If Not InSetup Then
            BtnApplySettings.Text = "Apply Setting Changes*"
        End If
    End Sub

    Private Sub NUDMaxClients_ValueChanged(sender As Object, e As EventArgs)
        If Not InSetup Then
            BtnApplySettings.Text = "Apply Setting Changes*"
        End If
    End Sub
#End Region
    Private Sub BtnApplySettings_Click(sender As Object, e As EventArgs) Handles BtnApplySettings.Click
        If True Then
            Dim CSE As String = ""
            Dim KEYU As String = ""
            If CBAllowHostedNetwork.Checked Then
                CSE = "Allow"
            Else
                CSE = "Disallow"
            End If
            If CbKeyIsTemp.Checked Then
                KEYU = "temporary"
            Else
                KEYU = "persistent"
            End If
            Dim command As String = String.Format("wlan set hostednetwork mode={0} ssid=""{1}"" key=""{2}"" KeyUsage={3}", CSE, TxtSSID.Text, TxtPassword.Text, KEYU)
            Console.WriteLine("Running Command: {0}", command)
            Dim CommandBase As New ProcessStartInfo With {
          .FileName = "netsh.exe",
          .Arguments = command,
          .UseShellExecute = False,
          .CreateNoWindow = True,
          .WindowStyle = ProcessWindowStyle.Hidden
      }
            Process.Start(CommandBase)

        End If
        BtnApplySettings.Text = "Apply Setting Changes"
    End Sub

    Private Sub BKPinger_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BKPinger.DoWork
        Do While True
            For Each row As DataGridViewRow In DGCClients.Rows
                Dim IP As String = row.Cells(1).Value
                Dim latency As Integer = Ping(IP)
                If Not IP.Contains("Resolving...") And Not IP = "" Then
                    If latency = 0 Then
                        row.Cells(4).Value = "Fail"
                    Else
                        row.Cells(4).Value = latency & "ms"
                    End If
                Else
                End If
            Next
            Threading.Thread.Sleep(1000)
        Loop
    End Sub
    Public Function Ping(Host As String) As Integer
        Try
            Dim pingreq As Ping = New Ping()
            Dim rep As PingReply = pingreq.Send(Host)
            Return rep.RoundtripTime
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
Public Class NetworkData
    Public Mode As String
    Public SSID As String
    Public BSSID As String
    Public MaxClients As Integer
    Public Authentication As String


    Public UserKey As String
    Public SystemSecurityKey As String
    Public KeyUsage As String

    Public Cipher As String
    Public Status As String
    Public RadioType As String
    Public Channel As Integer
    Public ClientCount As Integer
    Public Clients As New List(Of NetworkClient)
End Class
Public Class NetworkClient
    Public MACAddress As String
    Public Auth As String
    Public Sub New(Mac As String, Authed As String)
        MACAddress = Mac
        Auth = Authed
    End Sub
End Class
Public Class ClassRow
    Public ReadOnly ID As String
    Public MAC As String
    Public IP As String
    Public HOST As String
    Public Auth As String
    Public Sub New(NewAuth As String, NewHost As String, NewIP As String, NewMac As String)
        MAC = NewMac
        IP = NewIP
        HOST = NewHost
        Auth = NewAuth
        ID = String.Format("{0}{1}{2}{3}", MAC, IP, HOST, Auth)
    End Sub
End Class
