Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets

Public Class IPComp

    Structure IpInfo
        Dim IpAddress As String
        Dim HostName As String
        Dim MacAddress As String
    End Structure

    Public connectedIPAddresses As New List(Of IpInfo)

    Private Shared Function NetworkGateway() As String
        Dim ip As String = Nothing
        For Each f As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
            If f.OperationalStatus = OperationalStatus.Up Then
                For Each d As GatewayIPAddressInformation In f.GetIPProperties().GatewayAddresses
                    ip = d.Address.ToString()
                Next
            End If
        Next
        Return ip
    End Function
    Public Function GetGatewayIp()
        Dim SP As New ProcessStartInfo With {
           .FileName = "ipconfig.exe",
           .Arguments = "/all",
           .UseShellExecute = False,
           .CreateNoWindow = True,
           .RedirectStandardInput = True,
           .RedirectStandardOutput = True,
           .WindowStyle = ProcessWindowStyle.Hidden
       }
        Dim Myprocess As Process = Process.Start(SP)
        Dim retl As String = ""
        Do Until Myprocess.StandardOutput.EndOfStream
            Dim RL As String = Myprocess.StandardOutput.ReadLine
            If Not RL = "" Then
                Dim Modrl As String = RL.Trim(" ")

                If Modrl.ToLower.StartsWith("default gateway") Then
                    Dim spl1 As String = Modrl.Split(":")(1)
                    Dim spl2 As String = spl1.Trim(" ")

                    If spl2.Length > 1 Then
                        retl = spl2
                    End If
                End If


            End If
        Loop
        Return retl
    End Function
    Public Sub Ping_all()
        Console.WriteLine("Starting network scan")

        If True Then
            Try
                Dim gate_ip As String = GetGatewayIp()
                Dim array As String() = gate_ip.Split("."c)
                For i As Integer = 2 To 255
                    Dim ping_var As String = array(0) & "." & array(1) & "." & array(2) & "." & i.ToString
                    Ping(ping_var, 1, 1000)
                Next
                Task.WhenAll(taskList)
            Catch ex As Exception
            End Try
        End If

        If True Then


            Try
                Dim gate_ip As String = NetworkGateway()
                Dim array As String() = gate_ip.Split("."c)
                For i As Integer = 2 To 255
                    Dim ping_var As String = array(0) & "." & array(1) & "." & array(2) & "." & i.ToString
                    Ping(ping_var, 1, 1000)
                Next
                Task.WhenAll(taskList)
            Catch ex As Exception
            End Try
        End If

        Console.WriteLine("network scan finished")
    End Sub

    Dim taskList As New List(Of Task)

    Public Sub Ping(ByVal host As String, ByVal attempts As Integer, ByVal timeout As Integer)
        For i As Integer = 0 To attempts - 1
            taskList.Add(Task.Run(Sub()
                                      Try
                                          Dim ping As System.Net.NetworkInformation.Ping = New System.Net.NetworkInformation.Ping()
                                          AddHandler ping.PingCompleted, AddressOf PingCompleted
                                          ping.SendAsync(host, timeout, host)
                                      Catch
                                      End Try
                                  End Sub))
        Next

    End Sub

    Private Sub PingCompleted(ByVal sender As Object, ByVal e As PingCompletedEventArgs)
        Dim ip As String = CStr(e.UserState)
        If e.Reply IsNot Nothing AndAlso e.Reply.Status = IPStatus.Success Then
            Dim hostname As String = GetHostName(ip)
            Dim macaddres As String = GetMacAddress(ip)
            Dim newIpAddress As IpInfo
            newIpAddress.IpAddress = ip
            newIpAddress.MacAddress = macaddres
            newIpAddress.HostName = hostname
            connectedIPAddresses.Add(newIpAddress)
        Else
        End If
    End Sub

    Public Function GetHostName(ByVal ipAddress As String) As String
        Try
            Dim entry As IPHostEntry = Dns.GetHostEntry(ipAddress)
            If entry IsNot Nothing Then
                Return entry.HostName
            End If
        Catch __unusedSocketException1__ As SocketException
        End Try

        Return Nothing
    End Function

    Public Function GetMacAddress(ByVal ipAddress As String) As String
        Dim macAddress As String = String.Empty
        Dim Process As System.Diagnostics.Process = New System.Diagnostics.Process()
        Process.StartInfo.FileName = "arp"
        Process.StartInfo.Arguments = "-a " & ipAddress
        Process.StartInfo.UseShellExecute = False
        Process.StartInfo.RedirectStandardOutput = True
        Process.StartInfo.CreateNoWindow = True
        Process.Start()
        Dim strOutput As String = Process.StandardOutput.ReadToEnd()
        Dim substrings As String() = strOutput.Split("-"c)
        If substrings.Length >= 8 Then
            macAddress = substrings(3).Substring(Math.Max(0, substrings(3).Length - 2)) & "-" & substrings(4) & "-" & substrings(5) & "-" & substrings(6) & "-" & substrings(7) & "-" + substrings(8).Substring(0, 2)
            Return macAddress
        Else
            Return "OWN Machine"
        End If
    End Function

End Class