<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GBControl = New System.Windows.Forms.GroupBox()
        Me.BtnRestartNetwork = New System.Windows.Forms.Button()
        Me.BtnStopNetwork = New System.Windows.Forms.Button()
        Me.BtnStartNetwork = New System.Windows.Forms.Button()
        Me.BtnApplySettings = New System.Windows.Forms.Button()
        Me.LblBSSID = New System.Windows.Forms.Label()
        Me.LblCipher = New System.Windows.Forms.Label()
        Me.LblSSID = New System.Windows.Forms.Label()
        Me.LblMaxClients = New System.Windows.Forms.Label()
        Me.LblAuth = New System.Windows.Forms.Label()
        Me.GBClients = New System.Windows.Forms.GroupBox()
        Me.DGCClients = New System.Windows.Forms.DataGridView()
        Me.CMMAC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMHostName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMAuth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CBPing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TTSSID = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnShowPassword = New System.Windows.Forms.Button()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GBSettings = New System.Windows.Forms.GroupBox()
        Me.CbKeyIsTemp = New System.Windows.Forms.CheckBox()
        Me.CBAllowHostedNetwork = New System.Windows.Forms.CheckBox()
        Me.TxtSSID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BKDataUpdater = New System.ComponentModel.BackgroundWorker()
        Me.GBStatus = New System.Windows.Forms.GroupBox()
        Me.BKPinger = New System.ComponentModel.BackgroundWorker()
        Me.GBControl.SuspendLayout()
        Me.GBClients.SuspendLayout()
        CType(Me.DGCClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBSettings.SuspendLayout()
        Me.GBStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBControl
        '
        Me.GBControl.Controls.Add(Me.BtnRestartNetwork)
        Me.GBControl.Controls.Add(Me.BtnStopNetwork)
        Me.GBControl.Controls.Add(Me.BtnStartNetwork)
        Me.GBControl.Location = New System.Drawing.Point(13, 115)
        Me.GBControl.Name = "GBControl"
        Me.GBControl.Size = New System.Drawing.Size(211, 116)
        Me.GBControl.TabIndex = 1
        Me.GBControl.TabStop = False
        Me.GBControl.Text = "Control"
        '
        'BtnRestartNetwork
        '
        Me.BtnRestartNetwork.Location = New System.Drawing.Point(6, 77)
        Me.BtnRestartNetwork.Name = "BtnRestartNetwork"
        Me.BtnRestartNetwork.Size = New System.Drawing.Size(192, 23)
        Me.BtnRestartNetwork.TabIndex = 2
        Me.BtnRestartNetwork.Text = "Restart Network"
        Me.BtnRestartNetwork.UseVisualStyleBackColor = True
        '
        'BtnStopNetwork
        '
        Me.BtnStopNetwork.Location = New System.Drawing.Point(6, 48)
        Me.BtnStopNetwork.Name = "BtnStopNetwork"
        Me.BtnStopNetwork.Size = New System.Drawing.Size(192, 23)
        Me.BtnStopNetwork.TabIndex = 1
        Me.BtnStopNetwork.Text = "Stop Network"
        Me.BtnStopNetwork.UseVisualStyleBackColor = True
        '
        'BtnStartNetwork
        '
        Me.BtnStartNetwork.Location = New System.Drawing.Point(6, 19)
        Me.BtnStartNetwork.Name = "BtnStartNetwork"
        Me.BtnStartNetwork.Size = New System.Drawing.Size(192, 23)
        Me.BtnStartNetwork.TabIndex = 0
        Me.BtnStartNetwork.Text = "Start Network"
        Me.BtnStartNetwork.UseVisualStyleBackColor = True
        '
        'BtnApplySettings
        '
        Me.BtnApplySettings.Location = New System.Drawing.Point(-1, 149)
        Me.BtnApplySettings.Name = "BtnApplySettings"
        Me.BtnApplySettings.Size = New System.Drawing.Size(195, 23)
        Me.BtnApplySettings.TabIndex = 5
        Me.BtnApplySettings.Text = "Apply Setting Changes"
        Me.BtnApplySettings.UseVisualStyleBackColor = True
        '
        'LblBSSID
        '
        Me.LblBSSID.AutoSize = True
        Me.LblBSSID.Location = New System.Drawing.Point(7, 31)
        Me.LblBSSID.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.LblBSSID.Name = "LblBSSID"
        Me.LblBSSID.Size = New System.Drawing.Size(65, 13)
        Me.LblBSSID.TabIndex = 4
        Me.LblBSSID.Text = "BSSID: N/A"
        '
        'LblCipher
        '
        Me.LblCipher.AutoSize = True
        Me.LblCipher.Location = New System.Drawing.Point(7, 77)
        Me.LblCipher.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.LblCipher.Name = "LblCipher"
        Me.LblCipher.Size = New System.Drawing.Size(73, 13)
        Me.LblCipher.TabIndex = 3
        Me.LblCipher.Text = "Cipher: CCMP"
        '
        'LblSSID
        '
        Me.LblSSID.AutoSize = True
        Me.LblSSID.Location = New System.Drawing.Point(7, 14)
        Me.LblSSID.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.LblSSID.Name = "LblSSID"
        Me.LblSSID.Size = New System.Drawing.Size(58, 13)
        Me.LblSSID.TabIndex = 0
        Me.LblSSID.Text = "SSID: N/A"
        '
        'LblMaxClients
        '
        Me.LblMaxClients.AutoSize = True
        Me.LblMaxClients.Location = New System.Drawing.Point(7, 46)
        Me.LblMaxClients.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.LblMaxClients.Name = "LblMaxClients"
        Me.LblMaxClients.Size = New System.Drawing.Size(85, 13)
        Me.LblMaxClients.TabIndex = 1
        Me.LblMaxClients.Text = "Max Clients: 100"
        '
        'LblAuth
        '
        Me.LblAuth.AutoSize = True
        Me.LblAuth.Location = New System.Drawing.Point(7, 61)
        Me.LblAuth.Margin = New System.Windows.Forms.Padding(9, 0, 9, 0)
        Me.LblAuth.Name = "LblAuth"
        Me.LblAuth.Size = New System.Drawing.Size(161, 13)
        Me.LblAuth.TabIndex = 2
        Me.LblAuth.Text = "Authentification: WPA2-Personal"
        '
        'GBClients
        '
        Me.GBClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GBClients.Controls.Add(Me.DGCClients)
        Me.GBClients.Location = New System.Drawing.Point(227, 10)
        Me.GBClients.Name = "GBClients"
        Me.GBClients.Size = New System.Drawing.Size(578, 408)
        Me.GBClients.TabIndex = 2
        Me.GBClients.TabStop = False
        Me.GBClients.Text = "Clients"
        '
        'DGCClients
        '
        Me.DGCClients.AllowUserToAddRows = False
        Me.DGCClients.AllowUserToDeleteRows = False
        Me.DGCClients.AllowUserToOrderColumns = True
        Me.DGCClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGCClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGCClients.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CMMAC, Me.CMIP, Me.CMHostName, Me.CMAuth, Me.CBPing})
        Me.DGCClients.Location = New System.Drawing.Point(4, 17)
        Me.DGCClients.Name = "DGCClients"
        Me.DGCClients.ReadOnly = True
        Me.DGCClients.RowHeadersWidth = 13
        Me.DGCClients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGCClients.Size = New System.Drawing.Size(560, 382)
        Me.DGCClients.StandardTab = True
        Me.DGCClients.TabIndex = 0
        '
        'CMMAC
        '
        Me.CMMAC.HeaderText = "MAC Address"
        Me.CMMAC.Name = "CMMAC"
        Me.CMMAC.ReadOnly = True
        Me.CMMAC.Width = 150
        '
        'CMIP
        '
        Me.CMIP.HeaderText = "IP Address"
        Me.CMIP.Name = "CMIP"
        Me.CMIP.ReadOnly = True
        '
        'CMHostName
        '
        Me.CMHostName.HeaderText = "Host name"
        Me.CMHostName.Name = "CMHostName"
        Me.CMHostName.ReadOnly = True
        Me.CMHostName.Width = 125
        '
        'CMAuth
        '
        Me.CMAuth.HeaderText = "Authenticated"
        Me.CMAuth.Name = "CMAuth"
        Me.CMAuth.ReadOnly = True
        '
        'CBPing
        '
        Me.CBPing.HeaderText = "Latency"
        Me.CBPing.Name = "CBPing"
        Me.CBPing.ReadOnly = True
        Me.CBPing.Width = 75
        '
        'TTSSID
        '
        Me.TTSSID.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'BtnShowPassword
        '
        Me.BtnShowPassword.Location = New System.Drawing.Point(163, 120)
        Me.BtnShowPassword.Name = "BtnShowPassword"
        Me.BtnShowPassword.Size = New System.Drawing.Size(28, 23)
        Me.BtnShowPassword.TabIndex = 4
        Me.BtnShowPassword.Text = "//"
        Me.BtnShowPassword.UseVisualStyleBackColor = True
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(5, 123)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(152, 20)
        Me.TxtPassword.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Password:"
        '
        'GBSettings
        '
        Me.GBSettings.Controls.Add(Me.BtnApplySettings)
        Me.GBSettings.Controls.Add(Me.BtnShowPassword)
        Me.GBSettings.Controls.Add(Me.CbKeyIsTemp)
        Me.GBSettings.Controls.Add(Me.TxtPassword)
        Me.GBSettings.Controls.Add(Me.Label6)
        Me.GBSettings.Controls.Add(Me.CBAllowHostedNetwork)
        Me.GBSettings.Controls.Add(Me.TxtSSID)
        Me.GBSettings.Controls.Add(Me.Label8)
        Me.GBSettings.Location = New System.Drawing.Point(13, 237)
        Me.GBSettings.Name = "GBSettings"
        Me.GBSettings.Size = New System.Drawing.Size(211, 181)
        Me.GBSettings.TabIndex = 4
        Me.GBSettings.TabStop = False
        Me.GBSettings.Text = "Settings"
        '
        'CbKeyIsTemp
        '
        Me.CbKeyIsTemp.AutoSize = True
        Me.CbKeyIsTemp.Location = New System.Drawing.Point(5, 82)
        Me.CbKeyIsTemp.Name = "CbKeyIsTemp"
        Me.CbKeyIsTemp.Size = New System.Drawing.Size(107, 17)
        Me.CbKeyIsTemp.TabIndex = 5
        Me.CbKeyIsTemp.Text = "Key is Temporary"
        Me.CbKeyIsTemp.UseVisualStyleBackColor = True
        '
        'CBAllowHostedNetwork
        '
        Me.CBAllowHostedNetwork.AutoSize = True
        Me.CBAllowHostedNetwork.Location = New System.Drawing.Point(5, 59)
        Me.CBAllowHostedNetwork.Name = "CBAllowHostedNetwork"
        Me.CBAllowHostedNetwork.Size = New System.Drawing.Size(126, 17)
        Me.CBAllowHostedNetwork.TabIndex = 4
        Me.CBAllowHostedNetwork.Text = "Allow Hostednetwork"
        Me.CBAllowHostedNetwork.UseVisualStyleBackColor = True
        '
        'TxtSSID
        '
        Me.TxtSSID.Location = New System.Drawing.Point(5, 33)
        Me.TxtSSID.Name = "TxtSSID"
        Me.TxtSSID.Size = New System.Drawing.Size(167, 20)
        Me.TxtSSID.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "SSID:"
        '
        'BKDataUpdater
        '
        '
        'GBStatus
        '
        Me.GBStatus.Controls.Add(Me.LblBSSID)
        Me.GBStatus.Controls.Add(Me.LblSSID)
        Me.GBStatus.Controls.Add(Me.LblCipher)
        Me.GBStatus.Controls.Add(Me.LblAuth)
        Me.GBStatus.Controls.Add(Me.LblMaxClients)
        Me.GBStatus.Location = New System.Drawing.Point(10, 10)
        Me.GBStatus.Name = "GBStatus"
        Me.GBStatus.Size = New System.Drawing.Size(211, 99)
        Me.GBStatus.TabIndex = 5
        Me.GBStatus.TabStop = False
        Me.GBStatus.Text = "Status"
        '
        'BKPinger
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 430)
        Me.Controls.Add(Me.GBStatus)
        Me.Controls.Add(Me.GBSettings)
        Me.Controls.Add(Me.GBClients)
        Me.Controls.Add(Me.GBControl)
        Me.Name = "Form1"
        Me.Text = "Hosted Network Control"
        Me.GBControl.ResumeLayout(False)
        Me.GBClients.ResumeLayout(False)
        CType(Me.DGCClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBSettings.ResumeLayout(False)
        Me.GBSettings.PerformLayout()
        Me.GBStatus.ResumeLayout(False)
        Me.GBStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GBControl As GroupBox
    Friend WithEvents BtnRestartNetwork As Button
    Friend WithEvents BtnStopNetwork As Button
    Friend WithEvents BtnStartNetwork As Button
    Friend WithEvents GBClients As GroupBox
    Friend WithEvents DGCClients As DataGridView
    Friend WithEvents LblSSID As Label
    Friend WithEvents LblCipher As Label
    Friend WithEvents LblMaxClients As Label
    Friend WithEvents LblAuth As Label
    Friend WithEvents TTSSID As ToolTip
    Friend WithEvents BtnShowPassword As Button
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GBSettings As GroupBox
    Friend WithEvents CBAllowHostedNetwork As CheckBox
    Friend WithEvents TxtSSID As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnApplySettings As Button
    Friend WithEvents LblBSSID As Label
    Friend WithEvents CbKeyIsTemp As CheckBox
    Friend WithEvents BKDataUpdater As System.ComponentModel.BackgroundWorker
    Friend WithEvents GBStatus As GroupBox
    Friend WithEvents CMMAC As DataGridViewTextBoxColumn
    Friend WithEvents CMIP As DataGridViewTextBoxColumn
    Friend WithEvents CMHostName As DataGridViewTextBoxColumn
    Friend WithEvents CMAuth As DataGridViewTextBoxColumn
    Friend WithEvents CBPing As DataGridViewTextBoxColumn
    Friend WithEvents BKPinger As System.ComponentModel.BackgroundWorker
End Class
